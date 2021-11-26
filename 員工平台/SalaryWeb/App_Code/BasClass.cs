using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.Data;
using System.Collections;
using System.Net.Mail;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Reflection;

namespace SalaryWeb
{
    public class BasClass
    {
        public  int ENCODE(int ENCODE_TYPE, int VALT)
        {
            string LCFLAG = (VALT < 0) ? "-" : "+";
            VALT = Math.Abs(VALT);
            string VALSTR = VALT.ToString().Trim();
            string STR1 = "3761532470658472653034873";
            string LL = "";
            int VALLEN = 0;
            int STARTPOS = 0;
            switch (ENCODE_TYPE)
            {
                case 1:
                    VALLEN = VALSTR.Length;
                    STARTPOS = 0;
                    for (int I = 1; I <= VALLEN; I++)
                    {
                        STARTPOS = STARTPOS + int.Parse(VALSTR.Substring((I - 1 >= 0) ? I - 1 : 0, 1));
                        STARTPOS = STARTPOS % 10;
                    }
                    for (int I = 1; I <= VALLEN; I++)
                    {
                        int YY = 0;
                        int index = STARTPOS + I - 1 - 1;
                        if (index >= 0) YY = int.Parse(STR1.Substring(index, 1));
                        int WW = int.Parse(VALSTR.Substring((I - 1 >= 0) ? I - 1 : 0, 1)) + YY;
                        int iTmp = Math.Abs(WW) % 10;
                        LL += iTmp.ToString();
                    }
                    LL += VALLEN.ToString() + STARTPOS.ToString();
                    break;
                case 2:
                    string AA = VALSTR.Trim().Substring((VALSTR.Trim().Length - 2 >= 0) ? VALSTR.Trim().Length - 2 : 0, 2);
                    STARTPOS = int.Parse(AA.Substring((AA.Length - 1 >= 0) ? AA.Length - 1 : 0, 1));
                    VALLEN = int.Parse(AA.Substring(0, 1));
                    VALSTR = VALSTR.Substring(0, VALSTR.Length - 2).PadLeft(VALLEN, '0');
                    for (int I = 1; I <= VALLEN; I++)
                    {
                        int ZZ = int.Parse(VALSTR.Substring((I - 1 >= 0) ? I - 1 : 0, 1));
                        int index = STARTPOS + I - 1 - 1;
                        int YY = 0;
                        if (index >= 0) YY = int.Parse(STR1.Substring(index, 1));
                        int WW = ZZ - YY;
                        WW = (WW < 0) ? 10 + WW : WW;
                        int iTmp = Math.Abs(WW) % 10;
                        LL += iTmp.ToString();
                    }
                    break;
            }
            if (LL.Length == 0) LL = "0";
            LL = LCFLAG + LL;
            return int.Parse(LL);
        }

        public  int ENCODEDecimal(int ENCODE_TYPE, decimal VALT)
        {
            string LCFLAG = (VALT < 0) ? "-" : "+";
            VALT = Math.Abs(VALT);
            string VALSTR = VALT.ToString().Trim();
            string STR1 = "3761532470658472653034873";
            string LL = "";
            int VALLEN = 0;
            int STARTPOS = 0;
            switch (ENCODE_TYPE)
            {
                case 1:
                    VALLEN = VALSTR.Length;
                    STARTPOS = 0;
                    for (int I = 1; I <= VALLEN; I++)
                    {
                        STARTPOS = STARTPOS + int.Parse(VALSTR.Substring((I - 1 >= 0) ? I - 1 : 0, 1));
                        STARTPOS = STARTPOS % 10;
                    }
                    for (int I = 1; I <= VALLEN; I++)
                    {
                        int YY = 0;
                        int index = STARTPOS + I - 1 - 1;
                        if (index >= 0) YY = int.Parse(STR1.Substring(index, 1));
                        int WW = int.Parse(VALSTR.Substring((I - 1 >= 0) ? I - 1 : 0, 1)) + YY;
                        int iTmp = Math.Abs(WW) % 10;
                        LL += iTmp.ToString();
                    }
                    LL += VALLEN.ToString() + STARTPOS.ToString();
                    break;
                case 2:
                    string AA = VALSTR.Trim().Substring((VALSTR.Trim().Length - 2 >= 0) ? VALSTR.Trim().Length - 2 : 0, 2);
                    STARTPOS = int.Parse(AA.Substring((AA.Length - 1 >= 0) ? AA.Length - 1 : 0, 1));
                    VALLEN = int.Parse(AA.Substring(0, 1));
                    VALSTR = VALSTR.Substring(0, VALSTR.Length - 2).PadLeft(VALLEN, '0');
                    for (int I = 1; I <= VALLEN; I++)
                    {
                        int ZZ = int.Parse(VALSTR.Substring((I - 1 >= 0) ? I - 1 : 0, 1));
                        int index = STARTPOS + I - 1 - 1;
                        int YY = 0;
                        if (index >= 0) YY = int.Parse(STR1.Substring(index, 1));
                        int WW = ZZ - YY;
                        WW = (WW < 0) ? 10 + WW : WW;
                        int iTmp = Math.Abs(WW) % 10;
                        LL += iTmp.ToString();
                    }
                    break;
            }
            if (LL.Length == 0) LL = "0";
            LL = LCFLAG + LL;
            return int.Parse(LL);
        }


        public static SqlConnection GetConn()
        {
            //string SQL_CONNECTION_STRING = ConfigurationSettings.AppSettings["Sala_RepConnectionString"];
            //我的連線 HR資料庫連線方式固定採用 HRSqlServer，建議不要換，統一採用這個
            string SQL_CONNECTION_STRING = System.Configuration.ConfigurationManager.ConnectionStrings["HRSqlServer"].ConnectionString;
            string strConnection = SQL_CONNECTION_STRING;
            SqlConnection Con = new SqlConnection(strConnection);


            return Con;
        }

        public  DataTable GetBase(string Snobr, string DateB)
        {
            SqlConnection Conn = null;
            SqlCommand Cmd = null;
            Conn = BasClass.GetConn();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            DataTable rq_base = new DataTable();
            string Sql = "select b.nobr,a.name_c,a.name_e,c.d_no_disp as dept,c.d_name,b.indt,d.job_disp as job,d.job_name";
            Sql += ",b.indt,a.idno,b.comp,e.compname,b.jobl,f.jobs_disp as jobs,f.job_name as jobs_name,b.workcd";
            Sql += ",h.d_no_disp as depts,h.d_name as ds_name";
            Sql += " from base a,basetts b ";
            Sql += " left outer join dept c on b.dept=c.d_no";
            Sql += " left outer join job d on b.job=d.job";
            Sql += " left outer join comp e on b.comp=e.comp";
            Sql += " left outer join jobs f on b.jobs=f.jobs";
            Sql += " left outer join depts h on b.depts=h.d_no";
            Sql += string.Format(@" where b.nobr='{0}'", Snobr);
            Sql += string.Format(@" and '{0}' between b.adate and b.ddate", DateB);
            Sql += " and  a.nobr=b.nobr";
            Cmd.CommandText = Sql;
            SqlDataAdapter SCmd1a = new SqlDataAdapter(Cmd);
            SCmd1a.Fill(rq_base);
            return rq_base;
        }

        public DataTable GetWaged(string Snobr, string YYmm, string Seq, DataTable rq_base, bool salaryLang)
        {
            
            SqlConnection Conn = null;
            SqlCommand Cmd = null;
            Conn = BasClass.GetConn();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            DataTable rq_waged = new DataTable();

            string SqlCmd1 = "select b.nobr,c.sal_code_disp as sal_code,c.sal_name,c.sal_ename,b.amt,a.adate,a.account_no,d.flag,d.tax,d.type,a.note";
            SqlCmd1 += ",a.date_b,a.date_e,a.att_dateb,a.att_datee,a.wk_days,d.salattr";
            SqlCmd1 += " from  wage a,waged b ";
            SqlCmd1 += " left outer join salcode c on b.sal_code=c.sal_code";
            SqlCmd1 += " left outer join salattr d on c.sal_attr=d.salattr";
            SqlCmd1 += string.Format(@" where b.nobr='{0}' and b.yymm='{1}' and b.seq='{2}'", Snobr, YYmm, Seq);
            SqlCmd1 += " and a.nobr=b.nobr and a.yymm=b.yymm and a.seq=b.seq";
            SqlCmd1 += " and b.sal_code<>''";
            SqlCmd1 += " order by b.nobr,c.sal_attr,c.sal_code_disp ";
            Cmd.CommandText = SqlCmd1;
            SqlDataAdapter SCmd1b = new SqlDataAdapter(Cmd);
            SCmd1b.Fill(rq_waged);
            rq_waged.Columns.Add("compname", typeof(string));
            rq_waged.Columns.Add("name_c", typeof(string));
            rq_waged.Columns.Add("name_e", typeof(string));
            rq_waged.Columns.Add("dept", typeof(string));
            rq_waged.Columns.Add("d_name", typeof(string));
            rq_waged.Columns.Add("depts", typeof(string));
            rq_waged.Columns.Add("ds_name", typeof(string));
            rq_waged.Columns.Add("job", typeof(string));
            rq_waged.Columns.Add("job_name", typeof(string));
            rq_waged.Columns.Add("jobl", typeof(string));            
            rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };
            foreach (DataRow Row in rq_waged.Rows)
            {
                DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());
                int _i = 1;
                if (row != null)
                {
                    Row["name_c"] = row["name_c"].ToString();
                    Row["job"] = row["job"].ToString();
                    Row["job_name"] = row["job_name"].ToString();
                    Row["jobl"]=row["jobl"].ToString();
                    Row["dept"] = row["dept"].ToString();
                    Row["d_name"] = row["d_name"].ToString();
                    Row["depts"] = row["depts"].ToString();
                    Row["ds_name"] = row["ds_name"].ToString();
                    Row["compname"] = row["compname"].ToString();
                    Row["name_e"] = row["name_e"].ToString();
                    if (salaryLang)
                        Row["sal_name"] = Row["sal_ename"].ToString();
                }
                else
                    Row.Delete();
            }
            rq_waged.AcceptChanges();
            return rq_waged;
        }

        public  DataTable GetInslab(string Snobr, string DateB)
        {
            SqlConnection Conn = null;
            SqlCommand Cmd = null;
            Conn = BasClass.GetConn();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            DataTable rq_inslab = new DataTable();
            string Sql = " select a.nobr,a.h_amt from inslab a";
            Sql += " where a.nobr+a.fa_idno+convert(char,a.in_date,112) in";
            Sql += " (select nobr+fa_idno+max(convert(char,in_date,112)) from inslab";
            Sql += string.Format(@" where nobr='{0}'", Snobr);
            Sql += string.Format(@" and in_date<='{0}'  group by nobr,fa_idno)", DateB);
            Sql += " and a.fa_idno=''";
            Cmd.CommandText = Sql;
            SqlDataAdapter SCmd1a = new SqlDataAdapter(Cmd);
            SCmd1a.Fill(rq_inslab);
            foreach (DataRow Row in rq_inslab.Rows)
            {
                int _amt = (int)decimal.Parse(Row["h_amt"].ToString());
                Row["h_amt"] = ENCODE(2, _amt);
            }
            return rq_inslab;
        }

        public  DataTable GetBonus(string Snobr, string yy, string mm)
        {
            SqlConnection Conn = null;
            SqlCommand Cmd = null;
            Conn = BasClass.GetConn();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            //抓取薪資查詢轉帳日
            DataTable rq_adate = new DataTable();
            string sqlCmd = "select adate from wage ";
            sqlCmd += string.Format(@" where yymm='{0}'", yy + mm);
            Cmd.CommandText = sqlCmd;
            SqlDataAdapter SCmd1b = new SqlDataAdapter(Cmd);
            SCmd1b.Fill(rq_adate);
            string date_b = yy + "/01/01";
            string date_e = Convert.ToDateTime(yy + "/" + mm + "/01").AddMonths(2).AddDays(-1).ToString("yyyy/MM/dd");
            if (rq_adate.Rows.Count > 0)
                date_e = DateTime.Parse(rq_adate.Rows[0][0].ToString()).ToString("yyyy/MM/dd");
            DataTable rq_waged = new DataTable();
            string Sql = " select b.nobr,b.amt from wage a,waged b";
            Sql += " left outer join salcode c on b.sal_code=c.sal_code";
            Sql += string.Format(@" where a.nobr='{0}'", Snobr);
            Sql += string.Format(@" and adate between '{0}' and '{1}'", date_b, date_e);
            Sql += " and c.sup=1";
            Sql += " and a.nobr=b.nobr and a.yymm=b.yymm and a.seq=b.seq";
            Cmd.CommandText = Sql;
            SqlDataAdapter SCmd1a = new SqlDataAdapter(Cmd);
            SCmd1a.Fill(rq_waged);
            DataTable rq_bonus = new DataTable();
            rq_bonus.Columns.Add("nobr", typeof(string));
            rq_bonus.Columns.Add("amt", typeof(int));
            rq_bonus.PrimaryKey = new DataColumn[] { rq_bonus.Columns["nobr"] };
            foreach (DataRow Row in rq_waged.Rows)
            {
                int _amt = (int)decimal.Parse(Row["amt"].ToString());
                Row["amt"] = ENCODE(2, _amt);
                DataRow row = rq_bonus.Rows.Find(Row["nobr"].ToString());
                if (row != null)
                    row["amt"] = int.Parse(row["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                else
                {
                    DataRow aRow = rq_bonus.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["amt"] = int.Parse(Row["amt"].ToString());
                    rq_bonus.Rows.Add(aRow);
                }
            }
            return rq_bonus;
        }

        public DataTable GetAppConfig(string jobs)
        {
            SqlConnection Conn = null;
            SqlCommand Cmd = null;
            Conn = BasClass.GetConn();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            DataTable rq_AppConfig = new DataTable();
            string Sql = "select Value as Valuename from AppConfig where Category='ZZ42'";
            Sql += string.Format(@" and namep='{0}'", jobs);
            Cmd.CommandText = Sql;
            SqlDataAdapter SCmd1a = new SqlDataAdapter(Cmd);
            SCmd1a.Fill(rq_AppConfig);
            return rq_AppConfig;
        }
        public  DataTable GetExplab(string Snobr, string YYmm)
        {
            SqlConnection Conn = null;
            SqlCommand Cmd = null;
            Conn = BasClass.GetConn();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            DataTable rq_explab = new DataTable();
            string Sql = " select nobr,insur_type,exp,comp from explab";
            Sql += string.Format(@" where nobr='{0}'", Snobr);
            Sql += string.Format(@" and yymm='{0}'", YYmm);
            Cmd.CommandText = Sql;
            SqlDataAdapter SCmd1a = new SqlDataAdapter(Cmd);
            SCmd1a.Fill(rq_explab);
            return rq_explab;
        }

        public  DataTable GetOt(string Snobr, string YYmm)
        {
            SqlConnection Conn = null;
            SqlCommand Cmd = null;
            Conn = BasClass.GetConn();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            DataTable rq_ot = new DataTable();
            string Sql = "select a.nobr,a.ot_hrs,c.rote_disp as rote,a.nop_w_100,a.nop_w_133,a.nop_w_167,a.nop_w_200,a.nop_h_100,a.nop_h_133";
            Sql += ",a.nop_h_167,a.nop_h_200,a.not_w_100,a.not_w_133,a.not_w_167,a.not_w_200,a.not_h_133,a.not_h_167,a.not_h_200";
            Sql += ",a.tot_w_100,a.tot_w_133,a.tot_w_167,a.tot_w_200";
            Sql += " from ot a ,attend b,rote c ";
            Sql += " where a.nobr=b.nobr and a.bdate=b.adate and b.rote=c.rote";
            Sql += string.Format(@" and a.nobr='{0}'", Snobr);
            Sql += string.Format(@" and a.yymm='{0}' and a.fix_amt=0", YYmm);

            Cmd.CommandText = Sql;
            SqlDataAdapter SCmd1a = new SqlDataAdapter(Cmd);
            SCmd1a.Fill(rq_ot);
            return rq_ot;
        }

        public DataTable Get_Otaold1(string nobr, string yymm)
        {           
            SqlConnection Conn = null;
            SqlCommand Cmd = null;
            Conn = BasClass.GetConn();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            //20170214 薪資單加班時數顯示用文字不用倍率, 用 (平日加班 / 國定假日加班 / 例假日加班 / 休息日加班)
            DataTable rq_ot = new DataTable();
            rq_ot.Columns.Add("nobr", typeof(string));
            rq_ot.Columns.Add("wkhrs", typeof(decimal));
            rq_ot.Columns.Add("nationhrs", typeof(decimal));
            rq_ot.Columns.Add("holihrs", typeof(decimal));
            rq_ot.Columns.Add("resthrs", typeof(decimal));
            rq_ot.PrimaryKey = new DataColumn[] { rq_ot.Columns["nobr"] };
            string sqlCmd = "select a.nobr,b.rote,ot_hrs from ot a ,attend b ";
            sqlCmd += " where a.nobr=b.nobr and a.bdate=b.adate";
            sqlCmd += string.Format(@" and a.nobr = '{0}'", nobr);
            sqlCmd += string.Format(@" and a.yymm='{0}' and a.fix_amt=0", yymm);
            Cmd.CommandText = sqlCmd;
            SqlDataAdapter SCmd1a = new SqlDataAdapter(Cmd);
            DataTable rq_ot1 = new DataTable();
            SCmd1a.Fill(rq_ot1);
            foreach (DataRow Row in rq_ot1.Rows)
            {
                string rote = Row["rote"].ToString().Trim();
                DataRow row = rq_ot.Rows.Find(Row["nobr"].ToString());
                decimal wkhrs = 0; decimal nationhrs = 0; decimal holihrs = 0; decimal resthrs = 0;
                if (rote == "0X")
                    resthrs = decimal.Parse(Row["ot_hrs"].ToString());
                else if (rote == "0Z")
                    holihrs = decimal.Parse(Row["ot_hrs"].ToString());
                else if (rote == "00")
                    nationhrs = decimal.Parse(Row["ot_hrs"].ToString());
                else
                    wkhrs = decimal.Parse(Row["ot_hrs"].ToString());
                if (row != null)
                {
                    row["resthrs"] = decimal.Parse(row["resthrs"].ToString()) + resthrs;
                    row["holihrs"] = decimal.Parse(row["holihrs"].ToString()) + holihrs;
                    row["nationhrs"] = decimal.Parse(row["nationhrs"].ToString()) + nationhrs;
                    row["wkhrs"] = decimal.Parse(row["wkhrs"].ToString()) + wkhrs;
                }
                else
                {
                    DataRow aRow = rq_ot.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["resthrs"] = resthrs;
                    aRow["holihrs"] = holihrs;
                    aRow["nationhrs"] = nationhrs;
                    aRow["wkhrs"] = wkhrs;
                    rq_ot.Rows.Add(aRow);
                }
            }
            return rq_ot;

        }

        public DataTable GetOtaold(string Snobr, string YYmm)
        {
            SqlConnection Conn = null;
            SqlCommand Cmd = null;
            Conn = BasClass.GetConn();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            DataTable rq_ot = new DataTable();
            string Sql = "select nobr,ot_hrs,isHoli from FRM47 ";
            Sql += string.Format(@" where nobr = '{0}' ", Snobr);
            Sql += string.Format(@" and yymm='{0}' ", YYmm);
            Cmd.CommandText = Sql;
            SqlDataAdapter SCmd1a = new SqlDataAdapter(Cmd);
            SCmd1a.Fill(rq_ot);
            return rq_ot;
        }
        public  void Get_Ot1(DataTable DT_ot, DataTable Dt_ota)
        {
            foreach (DataRow Row in Dt_ota.Rows)
            {
                if (decimal.Parse(Row["nop_w_100"].ToString()) > 0)
                {
                    object[] _value = new object[2];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = decimal.Parse(Row["nop_w_100"].ToString());
                    DataRow row = DT_ot.Rows.Find(_value);
                    if (row != null)
                        row["othrs"] = decimal.Parse(row["othrs"].ToString()) + decimal.Parse(Row["not_w_100"].ToString());
                    else
                    {
                        DataRow aRow = DT_ot.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["rate"] = decimal.Parse(Row["nop_w_100"].ToString());
                        aRow["othrs"] = decimal.Parse(Row["not_w_100"].ToString());
                        DT_ot.Rows.Add(aRow);
                    }
                }
                if (decimal.Parse(Row["nop_w_133"].ToString()) > 0)
                {
                    object[] _value = new object[2];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = decimal.Parse(Row["nop_w_133"].ToString());
                    DataRow row = DT_ot.Rows.Find(_value);
                    if (row != null)
                    {
                        row["othrs"] = decimal.Parse(row["othrs"].ToString()) + decimal.Parse(Row["not_w_133"].ToString());
                        row["othrs"] = decimal.Parse(row["othrs"].ToString()) + decimal.Parse(Row["tot_w_133"].ToString());
                    }
                    else
                    {
                        DataRow aRow = DT_ot.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["rate"] = decimal.Parse(Row["nop_w_133"].ToString());
                        aRow["othrs"] = decimal.Parse(Row["not_w_133"].ToString());
                        aRow["othrs"] = decimal.Parse(aRow["othrs"].ToString()) + decimal.Parse(Row["tot_w_133"].ToString());
                        DT_ot.Rows.Add(aRow);
                    }
                }
                if (decimal.Parse(Row["nop_w_167"].ToString()) > 0)
                {
                    object[] _value = new object[2];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = decimal.Parse(Row["nop_w_167"].ToString());
                    DataRow row = DT_ot.Rows.Find(_value);
                    if (row != null)
                    {
                        row["othrs"] = decimal.Parse(row["othrs"].ToString()) + decimal.Parse(Row["not_w_167"].ToString());
                        row["othrs"] = decimal.Parse(row["othrs"].ToString()) + decimal.Parse(Row["tot_w_167"].ToString());
                    }
                    else
                    {
                        DataRow aRow = DT_ot.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["rate"] = decimal.Parse(Row["nop_w_167"].ToString());
                        aRow["othrs"] = decimal.Parse(Row["not_w_167"].ToString());
                        aRow["othrs"] = decimal.Parse(aRow["othrs"].ToString()) + decimal.Parse(Row["tot_w_167"].ToString());
                        DT_ot.Rows.Add(aRow);
                    }
                }
                if (decimal.Parse(Row["nop_w_200"].ToString()) > 0)
                {
                    object[] _value = new object[2];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = decimal.Parse(Row["nop_w_200"].ToString());
                    DataRow row = DT_ot.Rows.Find(_value);
                    if (row != null)
                    {
                        row["othrs"] = decimal.Parse(row["othrs"].ToString()) + decimal.Parse(Row["not_w_200"].ToString());
                        row["othrs"] = decimal.Parse(row["othrs"].ToString()) + decimal.Parse(Row["tot_w_200"].ToString());
                    }
                    else
                    {
                        DataRow aRow = DT_ot.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["rate"] = decimal.Parse(Row["nop_w_200"].ToString());
                        aRow["othrs"] = decimal.Parse(Row["not_w_200"].ToString());
                        aRow["othrs"] = decimal.Parse(aRow["othrs"].ToString()) + decimal.Parse(Row["tot_w_200"].ToString());
                        DT_ot.Rows.Add(aRow);
                    }
                }
                if (decimal.Parse(Row["nop_h_133"].ToString()) > 0)
                {
                    object[] _value = new object[2];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = decimal.Parse(Row["nop_h_133"].ToString());
                    DataRow row = DT_ot.Rows.Find(_value);
                    if (row != null)
                        row["othrs"] = decimal.Parse(row["othrs"].ToString()) + decimal.Parse(Row["not_h_133"].ToString());
                    else
                    {
                        DataRow aRow = DT_ot.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["rate"] = decimal.Parse(Row["nop_h_133"].ToString());
                        aRow["othrs"] = decimal.Parse(Row["not_h_133"].ToString());
                        DT_ot.Rows.Add(aRow);
                    }
                }
                if (decimal.Parse(Row["nop_h_167"].ToString()) > 0)
                {
                    object[] _value = new object[2];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = decimal.Parse(Row["nop_h_167"].ToString());
                    DataRow row = DT_ot.Rows.Find(_value);
                    if (row != null)
                        row["othrs"] = decimal.Parse(row["othrs"].ToString()) + decimal.Parse(Row["not_h_167"].ToString());
                    else
                    {
                        DataRow aRow = DT_ot.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["rate"] = decimal.Parse(Row["nop_h_167"].ToString());
                        aRow["othrs"] = decimal.Parse(Row["not_h_167"].ToString());
                        DT_ot.Rows.Add(aRow);
                    }
                }
                if (decimal.Parse(Row["nop_h_200"].ToString()) > 0)
                {
                    object[] _value = new object[2];
                    _value[0] = Row["nobr"].ToString();
                    _value[1] = decimal.Parse(Row["nop_h_200"].ToString());
                    DataRow row = DT_ot.Rows.Find(_value);
                    if (row != null)
                        row["othrs"] = decimal.Parse(row["othrs"].ToString()) + decimal.Parse(Row["not_h_200"].ToString());
                    else
                    {
                        DataRow aRow = DT_ot.NewRow();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["rate"] = decimal.Parse(Row["nop_h_200"].ToString());
                        aRow["othrs"] = decimal.Parse(Row["not_h_200"].ToString());
                        DT_ot.Rows.Add(aRow);
                    }
                }
            } 
        }

        //public  DataTable GetOt1(string Snobr, string YYmm)
        //{
        //    SqlConnection Conn = null;
        //    SqlCommand Cmd = null;
        //    Conn = BasClass.GetConn();
        //    Cmd = new SqlCommand();
        //    Cmd.Connection = Conn;
        //    DataTable rq_ot = new DataTable();
        //    string Sql = "select nobr,b.category,b.type_name,otbdate as bdate,otbtime as btime,otetime as etime,ot_hrs,not_exp,tot_exp,note";
        //    Sql += " from frm29 a";
        //    Sql += " left outer join overtime_type b on b.code=a.ottype";
        //    Sql += string.Format(@" where nobr='{0}'", Snobr);
        //    Sql += string.Format(@" and yymm= '{0}' ", YYmm);
        //    Sql += " and b.category='OverTime' and ot_hrs>0";
        //    Sql += " order by b.category,bdate,otbtime";
        //    Cmd.CommandText = Sql;
        //    SqlDataAdapter SCmd1a = new SqlDataAdapter(Cmd);
        //    SCmd1a.Fill(rq_ot);
        //    //foreach (DataRow Row in rq_ot.Rows)
        //    //{
        //    //    Row["not_exp"] = ENCODE(2, (int)decimal.Parse(Row["not_exp"].ToString()));
        //    //    Row["tot_exp"] = ENCODE(2, (int)decimal.Parse(Row["tot_exp"].ToString()));
        //    //}
        //    return rq_ot;
        //}

        public  DataTable GetOt2(string Snobr, string YYmm)
        {
            SqlConnection Conn = null;
            SqlCommand Cmd = null;
            Conn = BasClass.GetConn();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            DataTable rq_ot = new DataTable();
            string Sql = "select nobr,b.category,a.ottype,b.type_name,otbdate as  bdate,otbtime as btime,otetime as etime,ot_hrs,not_exp,tot_exp,note,a.eat";
            Sql += " from frm29 a";
            Sql += " left outer join overtime_type b on b.code=a.ottype";
            Sql += string.Format(@" where nobr='{0}'", Snobr);
            Sql += string.Format(@" and yymm= '{0}' ", YYmm);
            Sql += " and b.category not in ('OverTime','NoData') and ot_hrs>0";
            Sql += " order by b.category,bdate,otbtime";
            Cmd.CommandText = Sql;
            SqlDataAdapter SCmd1a = new SqlDataAdapter(Cmd);
            SCmd1a.Fill(rq_ot);
            //foreach (DataRow Row in rq_ot.Rows)
            //{
            //    Row["not_exp"] = ENCODE(2, (int)decimal.Parse(Row["not_exp"].ToString()));
            //    Row["tot_exp"] = ENCODE(2, (int)decimal.Parse(Row["tot_exp"].ToString()));
            //}
            return rq_ot;
        }

        public void Get_Ot3(DataTable DT_ot, DataTable Dt_ota)
        {
            foreach (DataRow Row in Dt_ota.Rows)
            {
                DataRow row = DT_ot.Rows.Find(Row["nobr"].ToString());
                if (row != null)
                {
                    //if (Row["rote"].ToString().Trim() == "00")
                    //    row["holihrs"] = decimal.Parse(row["holihrs"].ToString()) + decimal.Parse(Row["ot_hrs"].ToString());
                    //else
                    //    row["weekhrs"] = decimal.Parse(row["weekhrs"].ToString()) + decimal.Parse(Row["ot_hrs"].ToString());

                    //2013/08/27颱風加班計算規修改
                    if (Row["isHoli"].ToString().Trim() == "1")
                        row["holihrs"] = decimal.Parse(row["holihrs"].ToString()) + decimal.Parse(Row["ot_hrs"].ToString());
                    else
                        row["weekhrs"] = decimal.Parse(row["weekhrs"].ToString()) + decimal.Parse(Row["ot_hrs"].ToString());
                }
                else
                {
                    DataRow aRow = DT_ot.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["ot_100"] = 0;
                    aRow["ot_133"] = 0;
                    aRow["ot_150"] = 0;
                    aRow["ot_167"] = 0;
                    aRow["ot_200"] = 0;
                    aRow["ot_200_h"] = 0;
                    aRow["ot_250_h"] = 0;
                    aRow["weekhrs"] = 0;
                    aRow["holihrs"] = 0;
                    if (Row["isHoli"].ToString().Trim() == "1")
                        aRow["holihrs"] = decimal.Parse(Row["ot_hrs"].ToString());
                    else
                        aRow["weekhrs"] = decimal.Parse(Row["ot_hrs"].ToString());
                    DT_ot.Rows.Add(aRow);
                }
            }
        }

        public  DataTable Get_Ret(string Snobr, string YYmm, string date_b)
        {
            SqlConnection Conn = null;
            SqlCommand Cmd = null;
            Conn = BasClass.GetConn();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            DataTable rq_ret = new DataTable();
            string Sql = "select a.nobr,a.comp,a.exp,b.retrate,b.retchoo from explab a,basetts b";
            Sql += " where a.nobr=b.nobr";
            Sql += string.Format(@" and a.nobr= '{0}' ", Snobr);
            Sql += string.Format(@" and a.yymm='{0}'", YYmm);
            Sql += string.Format(@" and '{0}' between b.adate and b.ddate", date_b);
            Sql += " and a.insur_type='4'";
            Sql += " order by nobr";
            Cmd.CommandText = Sql;
            SqlDataAdapter SCmd1a = new SqlDataAdapter(Cmd);
            SCmd1a.Fill(rq_ret);
            foreach (DataRow Row in rq_ret.Rows)
            {
                int _comp = (int)decimal.Parse(Row["comp"].ToString());
            }
            return rq_ret;
        }

        public  DataTable Get_Attend(string Snobr, string attdate_b, string attdate_e)
        {
            SqlConnection Conn = null;
            SqlCommand Cmd = null;
            Conn = BasClass.GetConn();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            DataTable rq_attend = new DataTable();
            string Sql = "select nobr,sum(late_mins) as late_mins,sum(forget) as forget from attend";
            Sql += string.Format(@" where nobr = '{0}' ", Snobr);
            Sql += string.Format(@" and adate between '{0}' and '{1}'", attdate_b, attdate_e);
            Sql += " and (late_mins >0 or forget > 0)";
            Sql += " group by nobr";
            Cmd.CommandText = Sql;
            SqlDataAdapter SCmd1a = new SqlDataAdapter(Cmd);
            SCmd1a.Fill(rq_attend);
            //DataTable rq_attend1 = new DataTable();
            //rq_attend1.Columns.Add("nobr", typeof(string));
            //rq_attend1.Columns.Add("late_mins", typeof(int));
            //rq_attend1.Columns.Add("forget", typeof(int));
            //rq_attend1.PrimaryKey = new DataColumn[] { rq_attend1.Columns["nobr"] };
            //foreach (DataRow Row in rq_attend.Rows)
            //{
            //    int late = (int)decimal.Parse(Row["late_mins"].ToString());
            //    int forget = (int)decimal.Parse(Row["forget"].ToString());
            //    DataRow row = rq_attend1.Rows.Find(Row["nobr"].ToString());
            //    if (row != null)
            //    {
            //        if (late > 0) row["late_mins"] = int.Parse(row["late_mins"].ToString()) + 1;
            //        if (forget > 0) row["forget"] = int.Parse(row["forget"].ToString()) + 1;
            //    }
            //    else
            //    {
            //        DataRow aRow = rq_attend1.NewRow();
            //        aRow["nobr"] = Row["nobr"].ToString();
            //        aRow["late_mins"] = (late > 0) ? 1 : 0;
            //        aRow["forget"] = (forget > 0) ? 1 : 0;
            //        rq_attend1.Rows.Add(aRow);
            //    }
            //}
            return rq_attend;
        }

        public DataTable Get_Abs(string Snobr, string YYmm, bool salaryLang)
        {
            //and b.att=1判斷是否只顯示影響全勤
            SqlConnection Conn = null;
            SqlCommand Cmd = null;
            Conn = BasClass.GetConn();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            DataTable rq_abs = new DataTable();          
            string Sql = "select a.nobr,a.h_code,b.unit,";
            if (salaryLang)
                Sql += "b.h_ename as h_name,sum(a.tol_hours) as tol_hours";
            else
                Sql += "b.h_name as h_name,sum(a.tol_hours) as tol_hours";
            Sql += "  from abs a,hcode b where a.h_code =b.h_code ";
            //Sql += " and exists (select c.h_code from hcodes c where b.h_code=c.h_code and c.sal_code='A01') ";
            Sql += string.Format(@" and a.nobr = '{0}'", Snobr);
            Sql += string.Format(@" and a.yymm='{0}'", YYmm);
            Sql += " and  b.flag='-' and b.not_del='0'";
            if (salaryLang)
                Sql += " group by a.nobr,a.h_code,b.unit,b.h_ename";
            else
                Sql += " group by a.nobr,a.h_code,b.unit,b.h_name";
            Cmd.CommandText = Sql;
            SqlDataAdapter SCmd1a = new SqlDataAdapter(Cmd);
            SCmd1a.Fill(rq_abs);
            return rq_abs;
        }

        public  DataTable Get_Abs1(string Snobr, string date_e)
        {

            SqlConnection Conn = null;
            SqlCommand Cmd = null;
            Conn = BasClass.GetConn();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            DataTable rq_abs = new DataTable();

            DataTable rq_abs1 = new DataTable();
            rq_abs1.Columns.Add("nobr", typeof(string));
            rq_abs1.Columns.Add("gethrs", typeof(decimal)); //特休
            rq_abs1.Columns.Add("leave_hrs", typeof(decimal)); //特休
            rq_abs1.Columns.Add("gethrs2", typeof(decimal)); //特休延
            rq_abs1.Columns.Add("leave_hrs2", typeof(decimal)); //特休延
            rq_abs1.Columns.Add("rest_hrs", typeof(decimal));
            rq_abs1.PrimaryKey = new DataColumn[] { rq_abs1.Columns["nobr"] };
            string sqlCmd = "select a.nobr,b.htype,sum(a.balance) as tol_hours,sum(a.tol_hours) as gethrs";
            sqlCmd += "  from abs a,hcode b where a.h_code =b.h_code ";
            sqlCmd += string.Format(@" and a.nobr = '{0}'", Snobr);
            //sqlCmd += string.Format(@" and a.bdate between '{0}' and '{1}'", attdate_b, attdate_e);
            sqlCmd += string.Format(@" and '{0}' between a.bdate and a.edate", date_e);
            sqlCmd += " and b.htype between '1' and '2' and b.flag='+' and a.h_code !='W1' ";
            sqlCmd += " group by a.nobr,b.htype";
            Cmd.CommandText = sqlCmd;
            SqlDataAdapter SCmd1a = new SqlDataAdapter(Cmd);
            SCmd1a.Fill(rq_abs);
            foreach (DataRow Row in rq_abs.Rows)
            {
                string htype = Row["htype"].ToString().Trim();
                DataRow row = rq_abs1.Rows.Find(Row["nobr"].ToString());
                if (row != null)
                {
                    if (row != null)
                    {
                        if (htype == "1")
                        {
                            row["gethrs"] = decimal.Parse(row["gethrs"].ToString()) + decimal.Parse(Row["gethrs"].ToString());
                            row["leave_hrs"] = decimal.Parse(row["leave_hrs"].ToString()) + decimal.Parse(Row["tol_hours"].ToString());
                        }
                        else if (htype == "2")
                            row["rest_hrs"] = decimal.Parse(row["rest_hrs"].ToString()) + decimal.Parse(Row["tol_hours"].ToString());
                    }
                }
                else
                {
                    DataRow aRow = rq_abs1.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["gethrs"] = 0;
                    aRow["leave_hrs"] = 0;
                    aRow["gethrs2"] = 0;
                    aRow["leave_hrs2"] = 0;
                    aRow["rest_hrs"] = 0;
                    if (htype == "1")
                    {
                        aRow["leave_hrs"] = decimal.Parse(Row["tol_hours"].ToString());
                        aRow["gethrs"] = decimal.Parse(Row["gethrs"].ToString());

                    }
                    else if (htype == "2")
                        aRow["rest_hrs"] = decimal.Parse(Row["tol_hours"].ToString());
                    rq_abs1.Rows.Add(aRow);
                }
            }

            DataTable rq_abs2 = new DataTable();
            string sqlCmd1 = "select a.nobr,b.htype,sum(a.balance) as tol_hours,sum(a.tol_hours) as gethrs";
            sqlCmd1 += "  from abs a,hcode b where a.h_code =b.h_code ";
            sqlCmd1 += string.Format(@" and a.nobr = '{0}' ", Snobr);
            //sqlCmd += string.Format(@" and a.bdate between '{0}' and '{1}'", attdate_b, attdate_e);
            sqlCmd1 += string.Format(@" and '{0}' between a.bdate and a.edate", date_e);
            sqlCmd1 += " and a.h_code ='W1' ";
            sqlCmd1 += " group by a.nobr,b.htype";
            Cmd.CommandText = sqlCmd1;
            SqlDataAdapter SCmd1b = new SqlDataAdapter(Cmd);
            SCmd1b.Fill(rq_abs2);
            foreach (DataRow Row in rq_abs2.Rows)
            {

                DataRow row = rq_abs1.Rows.Find(Row["nobr"].ToString());
                if (row != null)
                {
                    if (row != null)
                    {
                        row["gethrs2"] = decimal.Parse(row["gethrs2"].ToString()) + decimal.Parse(Row["gethrs"].ToString());
                        row["leave_hrs2"] = decimal.Parse(row["leave_hrs2"].ToString()) + decimal.Parse(Row["tol_hours"].ToString());
                    }
                }
                else
                {
                    DataRow aRow = rq_abs1.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["gethrs"] = 0;
                    aRow["leave_hrs"] = 0;
                    aRow["rest_hrs"] = 0;
                    aRow["leave_hrs2"] = decimal.Parse(Row["tol_hours"].ToString());
                    aRow["gethrs2"] = decimal.Parse(Row["gethrs"].ToString());
                    rq_abs1.Rows.Add(aRow);
                }
            }
           
            return rq_abs1;
        }

       

        public class AnnualLeaveCashDto
        {
            public string CashType { get; set; }
            public string YYMM { get; set; }
            public string SEQ { get; set; }
            public string EmployeeID { get; set; }
            public string EmployeeName { get; set; }
            public string HoliCode { get; set; }
            public string HoliName { get; set; }
            public DateTime DateBegin { get; set; }
            public DateTime DateEnd { get; set; }
            public DateTime? DateOut { get; set; }
            public DateTime? DateStop { get; set; }
            public decimal Entitle { get; set; }
            public decimal Taken { get; set; }
            public decimal Balance { get; set; }
            public string Unit { get; set; }
            public decimal Salary { get; set; }
            public decimal CashOut { get; set; }
            public string Guid { get; set; }
            public string ErrorMsg { get; set; }
        }
        public DataTable Get_Annuaold(string Snobr, string attdate_b, string attdate_e)
        {

            SqlConnection Conn = null;
            SqlCommand Cmd = null;
            Conn = BasClass.GetConn();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            DataTable rq_abs = new DataTable();

            DataTable rq_abs1 = new DataTable();
            rq_abs1.Columns.Add("nobr", typeof(string));
            rq_abs1.Columns.Add("leave_hrs", typeof(decimal));
            rq_abs1.Columns.Add("rest_hrs", typeof(decimal));
            rq_abs1.PrimaryKey = new DataColumn[] { rq_abs1.Columns["nobr"] };
            //and b.att=1判斷是否只顯示影響全勤

            string sqlCmd0 = "select a.nobr,a.h_code,a.tol_hours,a.bdate,a.edate,b.year_rest ";
            sqlCmd0 += " from abs a,hcode b where a.h_code =b.h_code ";
            sqlCmd0 += string.Format(@" and a.nobr = '{0}' ", Snobr);
            if (DateTime.Parse(attdate_e).Year <= 2017)
                sqlCmd0 += string.Format(@" and a.bdate between '{0}' and'{1}'", attdate_b, attdate_e);
            else if (DateTime.Parse(attdate_e).Year == 2018)
                sqlCmd0 += string.Format(@" and a.bdate between '{0}' and'{1}'", "2017/01/01", attdate_e);
            else
                sqlCmd0 += string.Format(@" and '{0}' between a.bdate and a.edate", attdate_e);
            sqlCmd0 += " and b.year_rest in ('1','3','7') order by a.nobr,a.bdate";
            DataTable rq_abs0 = new DataTable();
            Cmd.CommandText = sqlCmd0;
            SqlDataAdapter SCmd1a = new SqlDataAdapter(Cmd);
            SCmd1a.Fill(rq_abs0);

            //失效日期小於薪資結算日
            DataTable rq_invalid1 = new DataTable();
            rq_invalid1.Columns.Add("nobr", typeof(string));
            rq_invalid1.Columns.Add("year_rest", typeof(string));
            rq_invalid1.Columns.Add("edate", typeof(DateTime));
            rq_invalid1.Columns.Add("tol_hours", typeof(decimal));
            rq_invalid1.Columns.Add("user_hrs", typeof(decimal));
            rq_invalid1.Columns.Add("invalid_hrs", typeof(decimal));
            rq_invalid1.PrimaryKey = new DataColumn[] { rq_invalid1.Columns["nobr"], rq_invalid1.Columns["year_rest"], rq_invalid1.Columns["edate"] };

            DataTable rq_absw = new DataTable();
            rq_absw = rq_abs0.Clone();
            rq_absw.PrimaryKey = new DataColumn[] { rq_absw.Columns["nobr"], rq_absw.Columns["year_rest"] };
            foreach (DataRow Row in rq_abs0.Rows)
            {
                int _bdate = Convert.ToInt32(DateTime.Parse(Row["bdate"].ToString()).ToString("yyyyMMdd"));
                //int _edate = Convert.ToInt32(DateTime.Parse(Row["edate"].ToString()).ToString("yyyyMMdd"));
                if (Row["year_rest"].ToString().Trim() == "7")
                    Row["year_rest"] = "1";
                object[] _value = new object[2];
                _value[0] = Row["nobr"].ToString();
                _value[1] = Row["year_rest"].ToString();
                DataRow row = rq_absw.Rows.Find(_value);
                if (row != null)
                {
                    int _bdate1 = Convert.ToInt32(DateTime.Parse(row["bdate"].ToString()).ToString("yyyyMMdd"));
                    if (_bdate1 > _bdate)
                        row["bdate"] = DateTime.Parse(Row["bdate"].ToString());
                    int _edate1 = Convert.ToInt32(DateTime.Parse(row["edate"].ToString()).ToString("yyyyMMdd"));
                    //if (_edate1<_edate)
                    //    row["edate"] = DateTime.Parse(Row["edate"].ToString());
                    row["tol_hours"] = decimal.Parse(row["tol_hours"].ToString()) + decimal.Parse(Row["tol_hours"].ToString());
                }
                else
                {
                    DataRow aRow = rq_absw.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["tol_hours"] = decimal.Parse(Row["tol_hours"].ToString());
                    aRow["bdate"] = DateTime.Parse(Row["bdate"].ToString());
                    aRow["edate"] = DateTime.Parse(attdate_e);
                    aRow["year_rest"] = Row["year_rest"].ToString();
                    rq_absw.Rows.Add(aRow);
                }

                //失效日期小於薪資結算日
                //begin
                int _edate = Convert.ToInt32(DateTime.Parse(Row["edate"].ToString()).ToString("yyyyMMdd"));
                int _attdatee = Convert.ToInt32(DateTime.Parse(attdate_e).ToString("yyyyMMdd"));
                if (_edate < _attdatee && Row["h_code"].ToString().Trim() == "W1")
                {
                    string sqlCmd01 = "select sum(a.tol_hours) as tol_hours from abs a,hcode b where a.h_code=b.h_code";
                    sqlCmd01 += string.Format(@" and a.nobr='{0}'", Row["nobr"].ToString());
                    sqlCmd01 += string.Format(@" and a.bdate between '{0}' and '{1}'", DateTime.Parse(Row["bdate"].ToString()).ToString("yyyy/MM/dd"), DateTime.Parse(Row["edate"].ToString()).ToString("yyyy/MM/dd"));
                    sqlCmd01 += " and a.h_code<>'W4' and b.year_rest in ('2')";
                    sqlCmd01 += (Row["year_rest"].ToString().Trim() == "1") ? " and b.year_rest in ('2','8')" : " and b.year_rest ='4'";
                    sqlCmd01 += " group by a.nobr";                    
                    DataTable rq_absw0 = new DataTable();
                    Cmd.CommandText = sqlCmd01;
                    SqlDataAdapter SCmd1ab = new SqlDataAdapter(Cmd);
                    SCmd1ab.Fill(rq_absw0);

                    if (rq_absw0.Rows.Count > 0)
                    {
                        foreach (DataRow Row1 in rq_absw0.Rows)
                        {
                            object[] _value1 = new object[3];
                            _value1[0] = Row["nobr"].ToString();
                            _value1[1] = Row["year_rest"].ToString();
                            _value1[2] = DateTime.Parse(Row["edate"].ToString());
                            DataRow row3 = rq_invalid1.Rows.Find(_value1);

                            if (row3 != null)
                            {
                                row3["tol_hours"] = decimal.Parse(row3["tol_hours"].ToString()) + decimal.Parse(Row["tol_hours"].ToString());
                                row3["user_hrs"] = decimal.Parse(row3["user_hrs"].ToString()) + decimal.Parse(Row1["tol_hours"].ToString());
                                row3["invalid_hrs"] = decimal.Parse(row3["tol_hours"].ToString()) - decimal.Parse(row3["user_hrs"].ToString());
                            }
                            else
                            {
                                DataRow aRow1 = rq_invalid1.NewRow();
                                aRow1["nobr"] = Row["nobr"].ToString();
                                aRow1["year_rest"] = Row["year_rest"].ToString();
                                aRow1["edate"] = DateTime.Parse(Row["edate"].ToString());
                                aRow1["tol_hours"] = decimal.Parse(Row["tol_hours"].ToString());
                                aRow1["user_hrs"] = decimal.Parse(Row1["tol_hours"].ToString());
                                aRow1["invalid_hrs"] = decimal.Parse(aRow1["tol_hours"].ToString()) - decimal.Parse(aRow1["user_hrs"].ToString());
                                rq_invalid1.Rows.Add(aRow1);
                            }
                        }
                    }
                    else
                    {
                        DataRow aRow1 = rq_invalid1.NewRow();
                        aRow1["nobr"] = Row["nobr"].ToString();
                        aRow1["year_rest"] = Row["year_rest"].ToString();
                        aRow1["edate"] = DateTime.Parse(Row["edate"].ToString());
                        aRow1["tol_hours"] = decimal.Parse(Row["tol_hours"].ToString());
                        aRow1["user_hrs"] = 0;
                        aRow1["invalid_hrs"] = decimal.Parse(aRow1["tol_hours"].ToString()) - decimal.Parse(aRow1["user_hrs"].ToString());
                        rq_invalid1.Rows.Add(aRow1);
                    }
                    rq_absw0.Clear();
                }
                //end
            }

            DataTable rq_invalid = new DataTable();
            rq_invalid.Columns.Add("nobr", typeof(string));
            rq_invalid.Columns.Add("year_rest", typeof(string));
            rq_invalid.Columns.Add("invalid_hrs", typeof(decimal));
            rq_invalid.PrimaryKey = new DataColumn[] { rq_invalid.Columns["nobr"], rq_invalid.Columns["year_rest"] };
            foreach (DataRow Row in rq_invalid1.Select("invalid_hrs>0"))
            {
                object[] _value1 = new object[2];
                _value1[0] = Row["nobr"].ToString();
                _value1[1] = Row["year_rest"].ToString();
                DataRow row3 = rq_invalid.Rows.Find(_value1);
                if (row3 != null)
                {
                    row3["invalid_hrs"] = decimal.Parse(row3["invalid_hrs"].ToString()) - decimal.Parse(Row["invalid_hrs"].ToString());
                }
                else
                {
                    DataRow aRow1 = rq_invalid.NewRow();
                    aRow1["nobr"] = Row["nobr"].ToString();
                    aRow1["year_rest"] = Row["year_rest"].ToString();
                    aRow1["invalid_hrs"] = decimal.Parse(Row["invalid_hrs"].ToString());
                    rq_invalid.Rows.Add(aRow1);
                }
            }

            foreach (DataRow Row in rq_absw.Rows)
            {
                //扣除剩餘時數
                DataRow[] SRow0 = rq_invalid.Select("nobr='" + Row["nobr"].ToString() + "' and year_rest='" + Row["year_rest"].ToString() + "'");
                decimal invalid_hrs = 0;
                for (int i = 0; i < SRow0.Length; i++)
                {
                    invalid_hrs += decimal.Parse(SRow0[0]["invalid_hrs"].ToString());
                }
                string sqlCmd01 = "select sum(a.tol_hours) as tol_hours from abs a,hcode b where a.h_code=b.h_code";
                sqlCmd01 += string.Format(@" and a.nobr='{0}'", Row["nobr"].ToString());
                sqlCmd01 += string.Format(@" and a.bdate between '{0}' and '{1}'", DateTime.Parse(Row["bdate"].ToString()).ToString("yyyy/MM/dd"), DateTime.Parse(Row["edate"].ToString()).ToString("yyyy/MM/dd"));
                sqlCmd01 += (Row["year_rest"].ToString().Trim() == "1") ? " and b.year_rest in ('2','8')" : " and b.year_rest ='4'";
                sqlCmd01 += " group by a.nobr";
                DataTable rq_absw0 = new DataTable();
                Cmd.CommandText = sqlCmd01;
                SqlDataAdapter SCmd1b = new SqlDataAdapter(Cmd);
                SCmd1b.Fill(rq_absw0);
                DataRow row = rq_abs1.Rows.Find(Row["nobr"].ToString());
                if (row != null)
                {
                    if (Row["year_rest"].ToString().Trim() == "1")
                        row["leave_hrs"] = (rq_absw0.Rows.Count > 0) ? decimal.Parse(Row["tol_hours"].ToString()) - decimal.Parse(rq_absw0.Rows[0]["tol_hours"].ToString()) : decimal.Parse(Row["tol_hours"].ToString());
                    else
                        row["rest_hrs"] = (rq_absw0.Rows.Count > 0) ? decimal.Parse(Row["tol_hours"].ToString()) - decimal.Parse(rq_absw0.Rows[0]["tol_hours"].ToString()) : decimal.Parse(Row["tol_hours"].ToString());
                }
                else
                {
                    DataRow aRow = rq_abs1.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["leave_hrs"] = 0;
                    aRow["rest_hrs"] = 0;
                    if (Row["year_rest"].ToString().Trim() == "1")
                        aRow["leave_hrs"] = (rq_absw0.Rows.Count > 0) ? decimal.Parse(Row["tol_hours"].ToString()) - decimal.Parse(rq_absw0.Rows[0]["tol_hours"].ToString()) : decimal.Parse(Row["tol_hours"].ToString());
                    else
                        aRow["rest_hrs"] = (rq_absw0.Rows.Count > 0) ? decimal.Parse(Row["tol_hours"].ToString()) - decimal.Parse(rq_absw0.Rows[0]["tol_hours"].ToString()) : decimal.Parse(Row["tol_hours"].ToString());
                    if (Row["year_rest"].ToString().Trim() == "1") aRow["leave_hrs"] = decimal.Parse(aRow["leave_hrs"].ToString()) - invalid_hrs;
                    rq_abs1.Rows.Add(aRow);
                }

                rq_absw0.Clear();
            }
            return rq_abs1;
        }

        public DataTable Get_Reta(string nobr_b, string date_b, string date_e)
        {
            SqlConnection Conn = null;
            SqlCommand Cmd = null;
            Conn = BasClass.GetConn();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            string sqlCmd = "select distinct a.nobr,a.in_date,a.r_amt,a.h_amt,a.l_amt from inslab a,basetts b";
            sqlCmd += " where a.nobr=b.nobr";
            sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
            sqlCmd += " and a.nobr+Convert(char(10),a.in_date,112)+a.fa_idno in ";
            sqlCmd += " (select nobr+Convert(char(10),max(in_date),112)+e.fa_idno from inslab e";
            sqlCmd += string.Format(@" where e.nobr = '{0}' ", nobr_b);
            sqlCmd += string.Format(@" and e.in_date<= '{0}' and e.out_date >='{1}' ", date_e, date_b);
            sqlCmd += " and e.fa_idno='' group by e.nobr,e.fa_idno) ";           
            sqlCmd += " order by a.nobr";
            Cmd.CommandText = sqlCmd;
            DataTable rq_inslab = new DataTable();           
            SqlDataAdapter SCmd1a = new SqlDataAdapter(Cmd);
            SCmd1a.Fill(rq_inslab);
            
            rq_inslab.Columns.Add("fa_cnt", typeof(int));

            sqlCmd = "select distinct a.nobr,count(a.nobr) as cnt from inslab a,basetts b";
            sqlCmd += " where a.nobr=b.nobr";
            sqlCmd += string.Format(@" and '{0}' between b.adate and b.ddate", date_e);
            sqlCmd += " and a.nobr+Convert(char(10),a.in_date,112)+a.fa_idno in ";
            sqlCmd += " (select nobr+Convert(char(10),max(in_date),112)+e.fa_idno from inslab e";
            sqlCmd += string.Format(@" where e.nobr = '{0}' ", nobr_b);
            sqlCmd += string.Format(@" and e.in_date<= '{0}' and e.out_date >='{1}' ", date_e, date_b);
            sqlCmd += " and e.fa_idno<>'' group by e.nobr,e.fa_idno) ";
            sqlCmd += " group by a.nobr";
            Cmd.CommandText = sqlCmd;
            DataTable rq_inslab1 = new DataTable();
            Cmd.CommandText = sqlCmd;
            SqlDataAdapter SCmd1b = new SqlDataAdapter(Cmd);
            SCmd1b.Fill(rq_inslab1);
            rq_inslab1.PrimaryKey = new DataColumn[] { rq_inslab1.Columns["nobr"] };

            foreach (DataRow Row in rq_inslab.Rows)
            {
                int _amt = (int)decimal.Parse(Row["r_amt"].ToString());
                Row["r_amt"] = ENCODE(2, _amt);
                _amt = (int)decimal.Parse(Row["h_amt"].ToString());
                Row["h_amt"] = ENCODE(2, _amt);
                _amt = (int)decimal.Parse(Row["l_amt"].ToString());
                Row["l_amt"] = ENCODE(2, _amt);                
                DataRow row = rq_inslab1.Rows.Find(Row["nobr"].ToString());
                if (row != null) Row["fa_cnt"] = int.Parse(row["cnt"].ToString());
            }
            return rq_inslab;
        }

        


        public  DataTable Get_Sala(DataTable DT_waged)
        {
            DataTable rq_sala = new DataTable();
            rq_sala.Columns.Add("nobr", typeof(string));
            rq_sala.Columns.Add("amt", typeof(int));
            rq_sala.Columns.Add("notaxamt", typeof(int));
            rq_sala.PrimaryKey = new DataColumn[] { rq_sala.Columns["nobr"] };
            DataRow[] row_waged = DT_waged.Select("salattr='D' or salattr='J' or salattr='M' or salattr='N'");
            foreach (DataRow Row in row_waged)
            {
                int _amt = (int)decimal.Parse(Row["amt"].ToString());
                _amt = ENCODE(2, _amt) * (-1);
                if (Row["flag"].ToString().Trim() == "-")
                    _amt = _amt * (-1);
                DataRow row = rq_sala.Rows.Find(Row["nobr"].ToString());
                if (row != null)
                    row["amt"] = int.Parse(row["amt"].ToString()) + _amt;
                else
                {
                    DataRow aRow = rq_sala.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["amt"] = _amt;
                    aRow["notaxamt"] = 0;
                    rq_sala.Rows.Add(aRow);
                }
            }

            DataRow[] row_waged1 = DT_waged.Select("salattr='G' or salattr='H' ");
            foreach (DataRow Row in row_waged1)
            {
                int _amt = (int)decimal.Parse(Row["amt"].ToString());
                _amt = ENCODE(2, _amt) * (-1);

                DataRow row1 = rq_sala.Rows.Find(Row["nobr"].ToString());
                if (row1 != null)
                    row1["notaxamt"] = int.Parse(row1["notaxamt"].ToString()) + _amt;
                else
                {
                    DataRow aRow1 = rq_sala.NewRow();
                    aRow1["nobr"] = Row["nobr"].ToString();
                    aRow1["amt"] = 0;
                    aRow1["notaxamt"] = _amt;
                    rq_sala.Rows.Add(aRow1);
                }
            }

            return rq_sala;
        }

        public  DataTable Get_AllRet(string Snobr, string yymm)
        {
            SqlConnection Conn = null;
            SqlCommand Cmd = null;
            Conn = BasClass.GetConn();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            DataTable rq_ret = new DataTable();
            string Sql = "select a.nobr,a.comp from explab a";
            Sql += string.Format(@" where a.nobr = '{0}' ", Snobr);
            //sqlCmd += string.Format(@" and left(a.yymm,4)='{0}'", yy);
            Sql += string.Format(@" and a.yymm <='{0}'", yymm);
            Sql += " and a.insur_type='4'";
            Sql += " order by nobr";
            Cmd.CommandText = Sql;
            SqlDataAdapter SCmd1a = new SqlDataAdapter(Cmd);
            SCmd1a.Fill(rq_ret);
            DataTable rq_yretcomp = new DataTable();
            rq_yretcomp.Columns.Add("nobr", typeof(string));
            rq_yretcomp.Columns.Add("comp", typeof(int));
            rq_yretcomp.PrimaryKey = new DataColumn[] { rq_yretcomp.Columns["nobr"] };
            foreach (DataRow Row in rq_ret.Rows)
            {
                int _amt = (int)decimal.Parse(Row["comp"].ToString());
                Row["comp"] = ENCODE(2, _amt);
                DataRow row = rq_yretcomp.Rows.Find(Row["nobr"].ToString());
                if (row != null)
                    row["comp"] = int.Parse(row["comp"].ToString()) + int.Parse(Row["comp"].ToString());
                else
                {
                    DataRow aRow = rq_yretcomp.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["comp"] = int.Parse(Row["comp"].ToString());
                    rq_yretcomp.Rows.Add(aRow);
                }
            }
            return rq_yretcomp;
        }

        public  DataTable Get_PersonRet(string Snobr, string yymm,string comp)
        {
            SqlConnection Conn = null;
            SqlCommand Cmd = null;
            Conn = BasClass.GetConn();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            DataTable rq_retsalcode = new DataTable();
            string Sql2 = "select retsalcode,nretirerate from u_sys4";
            Cmd.CommandText = Sql2;
            SqlDataAdapter SCmd1a2 = new SqlDataAdapter(Cmd);
            SCmd1a2.Fill(rq_retsalcode);
            string retcode = (rq_retsalcode.Rows.Count > 0) ? rq_retsalcode.Rows[0]["retsalcode"].ToString().Trim() : string.Empty;

            DataTable rq_ret = new DataTable();
            string Sql = "select a.nobr,b.amt from wage a,waged b";
            Sql += " where a.nobr=b.nobr and a.yymm=b.yymm and a.seq=b.seq ";
            Sql += string.Format(@" and a.nobr = '{0}'", Snobr);
            //sqlCmd += string.Format(@" and left(a.yymm,4)='{0}'", yymm.Substring(0, 4));
            Sql += string.Format(@" and a.yymm <='{0}'", yymm);
            Sql += string.Format(@" and b.sal_code ='{0}'", retcode);
            Sql += " order by nobr";
            Cmd.CommandText = Sql;
            SqlDataAdapter SCmd1a = new SqlDataAdapter(Cmd);
            SCmd1a.Fill(rq_ret);
            DataTable rq_personret = new DataTable();
            rq_personret.Columns.Add("nobr", typeof(string));
            rq_personret.Columns.Add("amt", typeof(int));
            rq_personret.PrimaryKey = new DataColumn[] { rq_personret.Columns["nobr"] };
            foreach (DataRow Row in rq_ret.Rows)
            {
                int _amt = (int)decimal.Parse(Row["amt"].ToString());
                Row["amt"] = ENCODE(2, _amt);
                DataRow row = rq_personret.Rows.Find(Row["nobr"].ToString());
                if (row != null)
                    row["amt"] = int.Parse(row["amt"].ToString()) + int.Parse(Row["amt"].ToString());
                else
                {
                    DataRow aRow = rq_personret.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["amt"] = int.Parse(Row["amt"].ToString());
                    rq_personret.Rows.Add(aRow);
                }
            }
            return rq_personret;
        }


        public void GetSalay(DataTable dt_salary, DataTable dt_waged, DataTable dt_ot, DataTable dt_abs, DataTable dt_abs1, DataTable dt_attend, DataTable dt_ret, DataTable dt_reta, DataTable rq_yretcomp,string comp, bool salaryLang)
        {
            //勞退自提
            SqlConnection Conn = null;
            SqlCommand Cmd = null;
            Conn = BasClass.GetConn();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            DataTable rq_retamt = new DataTable();
            string Sql = "select b.sal_code_disp as retsalcode,a.nretirerate from u_sys4 a left outer join salcode b on a.retsalcode=b.sal_code";
            Cmd.CommandText = Sql;
            SqlDataAdapter SCmd1a = new SqlDataAdapter(Cmd);
            SCmd1a.Fill(rq_retamt);
            string retcode = (rq_retamt.Rows.Count > 0) ? rq_retamt.Rows[0]["retsalcode"].ToString().Trim() : string.Empty;
            decimal nretirerate = (rq_retamt.Rows.Count > 0) ? decimal.Parse(rq_retamt.Rows[0]["nretirerate"].ToString()) : 0;
            //實發薪資
            DataTable wagedsz = new DataTable();
            wagedsz.Columns.Add("nobr", typeof(string));
            wagedsz.Columns.Add("tot1", typeof(string));
            wagedsz.PrimaryKey = new DataColumn[] { wagedsz.Columns["nobr"] };

            //勞退自提
            int _expamt = 0;

            foreach (DataRow Row in dt_waged.Rows)
            {
                int _amt = (int)decimal.Parse(Row["amt"].ToString());

                DataRow row = dt_salary.Rows.Find(Row["nobr"].ToString());
                if (Row["flag"].ToString().Trim() == "-")
                {
                    Row["amt"] = ENCODE(2, _amt) * (-1);
                }
                else
                    Row["amt"] = ENCODE(2, _amt);
                if (row == null)
                {
                    DataRow aRow = dt_salary.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["name_c"] = Row["name_c"].ToString();
                    aRow["name_e"] = Row["name_e"].ToString();
                    aRow["compname"] = Row["compname"].ToString();
                    aRow["dept"] = Row["dept"].ToString();
                    aRow["d_name"] = Row["d_name"].ToString();
                    aRow["depts"] = Row["depts"].ToString();
                    aRow["ds_name"] = Row["ds_name"].ToString();
                    aRow["account_no"] = Row["account_no"].ToString();
                    aRow["adate"] = DateTime.Parse(Row["adate"].ToString());
                    if (!Row.IsNull("att_dateb")) aRow["attdate_b"] = DateTime.Parse(Row["att_dateb"].ToString());
                    if (!Row.IsNull("att_datee")) aRow["attdate_e"] = DateTime.Parse(Row["att_datee"].ToString());
                    aRow["job"] = Row["job"].ToString();
                    aRow["job_name"] = Row["job_name"].ToString();
                    aRow["jobl"] = Row["jobl"].ToString();
                    aRow["wk_days"] = decimal.Round(decimal.Parse(Row["wk_days"].ToString()), 0);
                    aRow["note"] = Row["note"].ToString();
                   
                    dt_salary.Rows.Add(aRow);
                }
                DataRow row3 = wagedsz.Rows.Find(Row["nobr"].ToString());
                if (row3 != null)
                {
                    row3["tot1"] = int.Parse(Row["amt"].ToString()) + int.Parse(row3["tot1"].ToString());
                }
                else
                {
                    DataRow aRow = wagedsz.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["tot1"] = int.Parse(Row["amt"].ToString());
                    wagedsz.Rows.Add(aRow);
                }
                if (retcode.Trim() == Row["sal_code"].ToString().Trim())
                    _expamt = int.Parse(Row["amt"].ToString()) * (-1);
            }

            //應稅薪資
            DataTable wageds1 = new DataTable();
            wageds1.Columns.Add("nobr", typeof(string));
            wageds1.Columns.Add("tot1", typeof(int));
            wageds1.PrimaryKey = new DataColumn[] { wageds1.Columns["nobr"] };
            DataRow[] SRow1 = dt_waged.Select("salattr<='F'", "nobr asc");
            foreach (DataRow Rowa in SRow1)
            {
                DataRow row3 = wageds1.Rows.Find(Rowa["nobr"].ToString());
                if (row3 != null)
                {
                    row3["tot1"] = int.Parse(Rowa["amt"].ToString()) + int.Parse(row3["tot1"].ToString());
                }
                else
                {
                    DataRow aRow = wageds1.NewRow();
                    aRow["nobr"] = Rowa["nobr"].ToString();
                    aRow["tot1"] = int.Parse(Rowa["amt"].ToString());
                    wageds1.Rows.Add(aRow);
                }
            }

            //應發薪資
            DataTable wageds2 = new DataTable();
            wageds2.Columns.Add("nobr", typeof(string));
            wageds2.Columns.Add("tot1", typeof(string));
            wageds2.PrimaryKey = new DataColumn[] { wageds2.Columns["nobr"] };
            DataRow[] SRow2 = dt_waged.Select("salattr <='L' and sal_code <>'" + retcode + "'", "nobr asc");
            foreach (DataRow Rowb in SRow2)
            {
                DataRow row3 = wageds2.Rows.Find(Rowb["nobr"].ToString());
                if (row3 != null)
                {
                    row3["tot1"] = int.Parse(Rowb["amt"].ToString()) + int.Parse(row3["tot1"].ToString());
                }
                else
                {
                    DataRow aRow = wageds2.NewRow();
                    aRow["nobr"] = Rowb["nobr"].ToString();
                    aRow["tot1"] = int.Parse(Rowb["amt"].ToString());
                    wageds2.Rows.Add(aRow);
                }
            }

            foreach (DataRow Row1 in dt_salary.Rows)
            {
                //DataRow row = dt_ot.Rows.Find(Row1["nobr"].ToString());
                //if (row != null)
                //{
                //    Row1["notaxhrs"] = decimal.Parse(row["notaxhrs"].ToString());
                //    Row1["taxhrs"] = decimal.Parse(row["taxhrs"].ToString());
                //}

                DataRow[] SRow = dt_waged.Select("nobr='" + Row1["nobr"].ToString() + "' and flag=''", "sal_code asc");
                for (int i = 0; i < SRow.Length; i++)
                {
                    Row1["Fldbt" + (i + 1)] = SRow[i]["sal_name"].ToString();
                    Row1["Fldb" + (i + 1)] = decimal.Round(decimal.Parse(SRow[i]["amt"].ToString()), 0);
                }
                DataRow[] SRow3 = dt_waged.Select("nobr='" + Row1["nobr"].ToString() + "' and flag='-'", "sal_code asc");
                for (int i = 0; i < SRow3.Length; i++)
                {
                    Row1["Fldct" + (i + 1)] = SRow3[i]["sal_name"].ToString();
                    Row1["Fldc" + (i + 1)] = decimal.Round(decimal.Parse(SRow3[i]["amt"].ToString()), 0) * (-1);
                }

                DataRow[] row15 = dt_ot.Select("nobr='" + Row1["nobr"].ToString() + "' and othrs>0", "rate asc");
                int rowcnt = 1;
                int rowcount = (row15.Length > 5) ? 5 : row15.Length;
                for (int i = 0; i < rowcount; i++)
                {
                    if (decimal.Parse(row15[i]["othrs"].ToString()) > 0)
                    {
                        //if (salary_pa1)
                        //    Row1["Fldet" + rowcnt] = row15[i]["rate"].ToString() + " Times";
                        //else
                        //    Row1["Fldet" + rowcnt] = row15[i]["rate"].ToString() + " 倍";
                        Row1["Fldet" + rowcnt] = row15[i]["rate"].ToString() + " 倍";
                        Row1["Flde" + rowcnt] = decimal.Parse(row15[i]["othrs"].ToString());
                        rowcnt = rowcnt + 1;
                    }
                }

                //請假資料
                DataRow[] row4 = dt_abs.Select("nobr='" + Row1["nobr"].ToString() + "'", "h_code asc");
                for (int i = 0; i < row4.Length; i++)
                {
                    Row1["Fldat" + (i + 1)] = row4[i]["h_name"].ToString();
                    Row1["Flda" + (i + 1)] = decimal.Parse(row4[i]["tol_hours"].ToString());
                    if (salaryLang)
                    {
                        if (row4[i]["unit"].ToString().Trim() == "小時")
                            Row1["Fldau" + (i + 1)] = "hours";
                        else if (row4[i]["unit"].ToString().Trim() == "天")
                            Row1["Fldau" + (i + 1)] = "days";
                        else if (row4[i]["unit"].ToString().Trim() == "次")
                            Row1["Fldau" + (i + 1)] = "times";
                    }
                    else
                        Row1["Fldau" + (i + 1)] = row4[i]["unit"].ToString();

                }
                int _abscn = row4.Length + 1;
                DataRow row5 = dt_attend.Rows.Find(Row1["nobr"].ToString());
                if (row5 != null)
                {
                    if (decimal.Parse(row5["late_mins"].ToString()) > 0)
                    {
                        Row1["Flda" + _abscn] = decimal.Round(decimal.Parse(row5["late_mins"].ToString()), 0);
                        Row1["Fldat" + _abscn] = (salaryLang) ? "Arrive Late" : "遲到";
                        Row1["Fldau" + _abscn] = (salaryLang) ? "times" : "分鐘";
                        _abscn++;
                    }
                    if (decimal.Parse(row5["forget"].ToString()) > 0)
                    {
                        Row1["Flda" + _abscn] = decimal.Round(decimal.Parse(row5["forget"].ToString()), 0);
                        Row1["Fldat" + _abscn] = (salaryLang) ? "" : "忘刷";
                        Row1["Fldau" + _abscn] = (salaryLang) ? "times" : "次";
                    }
                }

                //勞退提撥
                DataRow row11 = dt_ret.Rows.Find(Row1["nobr"].ToString());
                if (row11 != null)
                {
                    if (row11["retchoo"].ToString().Trim() == "0")
                        Row1["Flddt5"] = "暫不選擇";
                    else if (row11["retchoo"].ToString().Trim() == "1")
                        Row1["Flddt5"] = "勞退舊制";
                    else if (row11["retchoo"].ToString().Trim() == "2")
                    {
                        Row1["Flddt5"] = "勞退新制";
                        Row1["Flddt7"] = decimal.Round(nretirerate * 100, 1);
                    }
                    if (decimal.Parse(row11["retrate"].ToString()) != 0) Row1["Flddt8"] = decimal.Round(decimal.Parse(row11["retrate"].ToString()), 1);

                    int _compamt = (int)decimal.Parse(row11["comp"].ToString());
                    int _exppamt = (int)decimal.Parse(row11["exp"].ToString());
                    Row1["Fldd7"] = ENCODE(2, _compamt);
                    if (_exppamt > 0) Row1["Fldd8"] = ENCODE(2, _exppamt);
                }

                DataRow row13 = dt_reta.Rows.Find(Row1["nobr"].ToString());
                if (row13 != null)
                {
                    Row1["Fldd6"] = int.Parse(row13["r_amt"].ToString());
                    Row1["h_amt"] = int.Parse(row13["h_amt"].ToString());
                    Row1["l_amt"] = int.Parse(row13["l_amt"].ToString());
                    if (!row13.IsNull("fa_cnt")) Row1["fa_cnt"] = int.Parse(row13["fa_cnt"].ToString());
                }

                DataRow row9 = wagedsz.Rows.Find(Row1["nobr"].ToString());
                if (row9 != null)
                {
                    Row1["Flddt3"] = (salaryLang) ? "Total Net Payable" : "實發金額";
                    Row1["Fldd3"] = int.Parse(row9["tot1"].ToString());
                }

                DataRow row10 = wageds1.Rows.Find(Row1["nobr"].ToString());
                if (row10 != null)
                {
                    Row1["Flddt4"] = "應稅薪資";
                    Row1["Fldd4"] = int.Parse(row10["tot1"].ToString());
                }

                DataRow row10a = wageds2.Rows.Find(Row1["nobr"].ToString());
                if (row10a != null)
                {
                    Row1["Flddt0"] = "應發薪資";
                    Row1["Fldd0"] = int.Parse(row10a["tot1"].ToString());
                }

                
                DataRow row12 = dt_abs1.Rows.Find(Row1["nobr"].ToString());
                if (row12 != null)
                {
                    Row1["getleave_hrs"] = decimal.Parse(row12["gethrs"].ToString());
                    Row1["leave_hrs"] = decimal.Parse(row12["leave_hrs"].ToString());
                    Row1["getleave_hrs2"] = decimal.Parse(row12["gethrs2"].ToString());
                    Row1["leave_hrs2"] = decimal.Parse(row12["leave_hrs2"].ToString());
                    Row1["rest_hrs"] = decimal.Parse(row12["rest_hrs"].ToString());
                }
               
                DataRow row17 = rq_yretcomp.Rows.Find(Row1["nobr"].ToString());
                if (row17 != null)
                    Row1["yretcomp"] = int.Parse(row17["comp"].ToString());                
                
            }
        }

        public  DataTable GetInJob(string Snobr)
        {
            SqlConnection Conn = null;
            SqlCommand Cmd = null;
            Conn = BasClass.GetConn();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            DataTable rq_injob = new DataTable();
            string Sql = "select a.nobr,a.name_c,a.name_e,a.birdt,a.idno";
            Sql += ",Round(datediff(d,dateadd(day,dbo.GetStopDays(a.nobr,isnull(b.indt1,b.indt),getdate()),isnull(b.indt1,b.indt)),getdate())/365.24,2) as wk_yrs";
            Sql += ",dateadd(day,dbo.GetStopDays(a.nobr,isnull(b.indt1,b.indt),getdate()),isnull(b.indt1,b.indt)) as indt";
            ////20150819到職日應為特休截止日
            //Sql += ",[dbo].[GetTotalYears1](b.nobr,b.indt1) as wk_yrs";
            //Sql += ",b.indt1 as indt";
            //Sql += ",DBO.GETTOTALYEARS(A.NOBR,getdate()) AS WK_YRS ";
            Sql += ",c.d_no_disp as dept,c.d_name,d.job_disp as job,d.job_name,b.oudt";
            Sql += " from base a,basetts b";
            Sql += " left outer join dept c on b.dept=c.d_no";
            Sql += " left outer join job d on b.job=d.job";
            Sql += string.Format(@" where a.nobr='{0}'", Snobr);
            Sql += " and getdate() between b.adate and b.ddate";
            Sql += " and a.nobr=b.nobr";
            Cmd.CommandText = Sql;
            SqlDataAdapter SCmd1a = new SqlDataAdapter(Cmd);
            SCmd1a.Fill(rq_injob);
            return rq_injob;
        }

        public  DataTable GetSalBasd(string Snobr)
        {
            SqlConnection Conn = null;
            SqlCommand Cmd = null;
            Conn = BasClass.GetConn();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            DataTable rq_salbasd = new DataTable();
            string Sql = "select a.nobr,b.sal_code_disp,a.amt";
            Sql += " from salbasd a,salcode b";
            Sql += string.Format(@" where '{0}' between a.adate and a.ddate", DateTime.Now.ToString("yyyy/MM/dd"));
            Sql += string.Format(@" and a.nobr='{0}'", Snobr);
            Sql += " and b.sal_code_disp in ('A01','A02','A06')";
            Sql += " and a.sal_code=b.sal_code order by a.nobr,b.sal_code_disp";
            Cmd.CommandText = Sql;
            SqlDataAdapter SCmd1a = new SqlDataAdapter(Cmd);
            SCmd1a.Fill(rq_salbasd);


            return rq_salbasd;
        }

        public  void GetYearSalay(DataTable dt_yearsalary, DataTable dt_salbasd, DataTable dt_base)
        {
            dt_base.PrimaryKey = new DataColumn[] { dt_base.Columns["nobr"] };
            dt_yearsalary.PrimaryKey = new DataColumn[] { dt_yearsalary.Columns["nobr"] };
            foreach (DataRow Row in dt_salbasd.Rows)
            {
                string salcode = Row["sal_code_disp"].ToString().Trim();
                DataRow row = dt_base.Rows.Find(Row["nobr"].ToString());
                if (row != null)
                {
                    int _amt = (int)decimal.Parse(Row["amt"].ToString());
                    Row["amt"] = ENCODE(2, _amt);

                    DataRow row1 = dt_yearsalary.Rows.Find(Row["nobr"].ToString());
                    if (row1 != null)
                    {
                        if (salcode == "A01")
                        {
                            row1["basesalary"] = int.Parse(Row["amt"].ToString());
                            row1["yearbase"] = int.Parse(Row["amt"].ToString()) * 12;
                            row1["fixbonus"] = int.Parse(Row["amt"].ToString()) * 2;
                            row1["yearsalary"] = int.Parse(row1["yearsalary"].ToString()) + int.Parse(Row["amt"].ToString()) * 12;
                        }
                        else if (salcode == "A02")
                        {
                            row1["fieldallowance"] = int.Parse(Row["amt"].ToString());
                            row1["totalAllowance"] = int.Parse(row1["totalAllowance"].ToString()) + int.Parse(Row["amt"].ToString());
                            row1["yearsalary"] = int.Parse(row1["yearsalary"].ToString()) + int.Parse(Row["amt"].ToString()) * 12;
                        }
                        else if (salcode == "A06")
                        {
                            row1["phoneallowance"] = int.Parse(Row["amt"].ToString());
                            row1["totalAllowance"] = int.Parse(row1["totalAllowance"].ToString()) + int.Parse(Row["amt"].ToString());
                        }
                    }
                    else
                    {
                        DataRow aRow = dt_yearsalary.NewRow();
                        aRow["dept"] = row["dept"].ToString();
                        aRow["d_name"] = row["d_name"].ToString();
                        aRow["job"] = row["job"].ToString();
                        aRow["job_name"] = row["job_name"].ToString();
                        aRow["nobr"] = Row["nobr"].ToString();
                        aRow["name_c"] = row["name_c"].ToString();
                        aRow["name_e"] = row["name_e"].ToString();
                        aRow["indt"] = DateTime.Parse(row["indt"].ToString());
                        aRow["totalAllowance"] = 0;
                        aRow["yearsalary"] = 0;
                        if (salcode == "A01")
                        {
                            aRow["basesalary"] = int.Parse(Row["amt"].ToString());
                            aRow["yearbase"] = int.Parse(Row["amt"].ToString()) * 12;
                            aRow["fixbonus"] = int.Parse(Row["amt"].ToString()) * 2;
                            aRow["yearsalary"] = int.Parse(aRow["yearsalary"].ToString()) + int.Parse(Row["amt"].ToString()) * 12;
                        }
                        else if (salcode == "A02")
                        {
                            aRow["fieldallowance"] = int.Parse(Row["amt"].ToString());
                            aRow["totalAllowance"] = int.Parse(Row["amt"].ToString());
                            aRow["yearsalary"] = int.Parse(aRow["yearsalary"].ToString()) + int.Parse(Row["amt"].ToString()) * 12;
                        }
                        else if (salcode == "A06")
                        {
                            aRow["phoneallowance"] = int.Parse(Row["amt"].ToString());
                            aRow["totalAllowance"] = int.Parse(Row["amt"].ToString());
                        }
                        dt_yearsalary.Rows.Add(aRow);
                    }
                }
            }
        }

        public DataTable GetYrtax(string sNobr, string Year)
        {
            SqlConnection Conn = null;
            SqlCommand Cmd = null;
            Conn = BasClass.GetConn();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            DataTable rq_yrtax = new DataTable();
            DataTable rq_dept = new DataTable();
            Cmd.CommandText = "select d_no,d_no_disp,d_name,d_ename from dept";
            SqlDataAdapter SCmdlb = new SqlDataAdapter(Cmd);
            SCmdlb.Fill(rq_dept);
            rq_dept.PrimaryKey = new DataColumn[] { rq_dept.Columns["d_no"] };


            string Sql = "select b.dept,c.name_c as name_e,c.*,e.compname,e.chairman,e.addr as compaddr,e.compid,";
            Sql += "f.m_fmt_name as formatname";
            Sql += " from base a,basetts b,yrtax1 c";
            Sql += " left outer join comp e on c.id1=e.compid";
            Sql += " left outer join yrformat f on c.format=f.m_format";
            Sql += "  where c.nobr=b.nobr and a.nobr=b.nobr ";
            Sql += string.Format(@" and '{0}' between b.adate and b.ddate", Year + "/12/31");
            //Sql += string.Format(@" and a.idno='{0}'", Idno);
            Sql += string.Format(@" and c.nobr='{0}'", sNobr);
            Sql += string.Format(@" and c.year='{0}'", Year);
            Sql += " order by c.format";
            Cmd.CommandText = Sql;
            SqlDataAdapter SCmd1a = new SqlDataAdapter(Cmd);
            SCmd1a.Fill(rq_yrtax);
            rq_yrtax.Columns.Add("d_name", typeof(string));
            rq_yrtax.Columns.Add("d_ename", typeof(string));
            foreach (DataRow Row in rq_yrtax.Rows)
            {
                decimal _totamt = decimal.Round(decimal.Parse(Row["tot_amt"].ToString()), 0);
                decimal _relamt = decimal.Round(decimal.Parse(Row["rel_amt"].ToString()), 0);
                decimal _taxamt = decimal.Round(decimal.Parse(Row["tax_amt"].ToString()), 0);
                decimal _retamt = decimal.Round(decimal.Parse(Row["ret_amt"].ToString()), 0);
		Row["year_b"] = Convert.ToString(Convert.ToInt32(Row["year_b"].ToString().Substring(0, 4)) - 1911) + Row["year_b"].ToString().Substring(4, 2);
                Row["year_e"] = Convert.ToString(Convert.ToInt32(Row["year_e"].ToString().Substring(0, 4)) - 1911) + Row["year_e"].ToString().Substring(4, 2);
                Row["nobr"] = Row["nobr"].ToString().Trim();
                if (_totamt > 0) Row["tot_amt"] = ENCODEDecimal(2, _totamt);
                if (_relamt > 0) Row["rel_amt"] = ENCODEDecimal(2, _relamt);
                if (_taxamt > 0) Row["tax_amt"] = ENCODEDecimal(2, _taxamt);
                if (_retamt > 0) Row["ret_amt"] = ENCODEDecimal(2, _retamt);
                DataRow row = rq_dept.Rows.Find(Row["dept"].ToString());
                if (row != null)
                {
                    Row["dept"] = row["d_no_disp"].ToString();
                    Row["d_name"] = row["d_name"].ToString();
                    Row["d_ename"] = row["d_ename"].ToString();
                }
            }
            return rq_yrtax;
        }

        public  DataTable GetComp(string Comp)
        {
            SqlConnection Conn = null;
            SqlCommand Cmd = null;
            Conn = BasClass.GetConn();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            DataTable rq_comp = new DataTable();
            string Sql = "select compname,chairman,addr,tel,compid from comp ";
            Sql += string.Format(@" where comp='{0}'", Comp);
            Cmd.CommandText = Sql;
            SqlDataAdapter SCmd1a = new SqlDataAdapter(Cmd);
            SCmd1a.Fill(rq_comp);
            return rq_comp;
        }

        public  DataTable GetSysUserRole(string Nobr)
        {
            SqlConnection Conn = null;
            SqlCommand Cmd = null;
            Conn = BasClass.GetConn();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            DataTable rq_SysUserRole = new DataTable();
            string Sql = "select nobr from sysuserrole where rolecode='HR' ";
            Sql += string.Format(@" and nobr='{0}'", Nobr);
            Cmd.CommandText = Sql;
            SqlDataAdapter SCmd1a = new SqlDataAdapter(Cmd);
            SCmd1a.Fill(rq_SysUserRole);
            return rq_SysUserRole;
        }

        /// Todo 薪資單Payslip薪資年月查詢條件,sYear=>年,sMonth=>月,Seq=>期別,Meno=>備註
        public  DataTable Get_LockWage(string Nobr)
        {		
            SqlConnection Conn = null;
            SqlCommand Cmd = null;
            Conn = BasClass.GetConn();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            DataTable rq_lockwage = new DataTable();
            string Sql = "select substring(rtrim(a.yymm),0,5) as sYear,substring(rtrim(a.yymm),5,2) as sMonth,a.Seq,a.Meno";
            Sql += " from lock_wage a,wage b where   a.yymm=b.yymm and a.seq=b.seq and a.saladr=b.saladr";
            Sql += string.Format(@" and b.adate <=getdate() and b.nobr='{0}'", Nobr);
            Sql += " order by a.yymm desc";
	    Cmd.CommandText = Sql;
            SqlDataAdapter SCmd1a = new SqlDataAdapter(Cmd);
            SCmd1a.Fill(rq_lockwage);
            return rq_lockwage;
        }
      
	
	/// Todo 年度所得TaxSatement年度查詢條件,sValue=>年,sText=>備註說明
        public  DataTable Get_LockIncome()
        {		
            SqlConnection Conn = null;
            SqlCommand Cmd = null;
            Conn = BasClass.GetConn();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            DataTable rq_lockwage = new DataTable();
            string Sql = "select year as sValue,note as sText from lock_yr where YEAR <=year(getdate()) and type_name='年度所得' and adate < getdate() order by year desc";
	    Cmd.CommandText = Sql;
            SqlDataAdapter SCmd1a = new SqlDataAdapter(Cmd);
            SCmd1a.Fill(rq_lockwage);        
            return rq_lockwage;
        }

	/// Todo 保費證明單InsCertificate年度查詢條件,sValue=>年,sText=>備註說明
        public  DataTable Get_LockInsurance()
        {
            SqlConnection Conn = null;
            SqlCommand Cmd = null;
            Conn = BasClass.GetConn();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            DataTable rq_lockwage = new DataTable();
            string Sql = "select year as sValue,note as sText from lock_yr where YEAR <=year(getdate()) and type_name='保費證明' and adate < getdate() order by year desc";
	    Cmd.CommandText = Sql;
            SqlDataAdapter SCmd1a = new SqlDataAdapter(Cmd);
            SCmd1a.Fill(rq_lockwage);
            return rq_lockwage;
        }

        public  DataTable GetYrinsur(string Snobr, string Year)
        {
            SqlConnection Conn = null;
            SqlCommand Cmd = null;
            Conn = BasClass.GetConn();
            Cmd = new SqlCommand();
            Cmd.Connection = Conn;
            DataTable rq_dt = new DataTable();
            string Sql = "select c.nobr,d.fa_idno,d.fa_birdt,d.fa_name,c.rel_lab,c.rel_hel,c.rel_grp,c.rel_sup,";
            Sql += "a.idno,a.name_c,a.name_e,b.dept,f.d_name,b.depts,b.workcd,d.fa_name,e.rel_name";
            Sql += ",g.compname as insname,g.chairman as insman,g.addr  as insaddr,g.tel as instel";
            Sql += " from base a,basetts b,comp g,dept f,yrinsur c";
            Sql += " left outer join family d on c.fa_idno=d.fa_idno and c.nobr=d.nobr";
            Sql += " left outer join relcode e on d.rel_code=e.rel_code";
            //Sql += " left outer join inscomp g on c.s_no=g.s_no";
            Sql += "  where c.nobr=b.nobr and a.nobr=b.nobr and b.comp=g.comp and b.dept=f.d_no";
            Sql += string.Format(@" and '{0}' between b.adate and b.ddate", Year + "/12/31");
            Sql += string.Format(@" and c.nobr='{0}'", Snobr);
            Sql += string.Format(@" and c.year='{0}'", Year);
            Sql += " order by c.nobr,c.fa_idno";
            Cmd.CommandText = Sql;
            SqlDataAdapter SCmd1a = new SqlDataAdapter(Cmd);
            SCmd1a.Fill(rq_dt);
            rq_dt.Columns.Add("work_addr", typeof(string));

            DataTable rq_workcd = new DataTable();
            Cmd.CommandText = "select work_code,work_addr from workcd";
            SqlDataAdapter SCmd1b = new SqlDataAdapter(Cmd);
            SCmd1b.Fill(rq_workcd);
            rq_workcd.PrimaryKey = new DataColumn[] { rq_workcd.Columns["work_code"] };

            foreach (DataRow Row in rq_dt.Rows)
            {

                int rellab = (int)decimal.Parse(Row["rel_lab"].ToString());
                int relhel = (int)decimal.Parse(Row["rel_hel"].ToString());
                int relgrp = (int)decimal.Parse(Row["rel_grp"].ToString());
                int relsup = (Row.IsNull("rel_sup")) ? 10 : (int)decimal.Parse(Row["rel_sup"].ToString());
                Row["nobr"] = Row["nobr"].ToString().Trim();
                Row["rel_lab"] = ENCODE(2, rellab);
                Row["rel_hel"] = ENCODE(2, relhel);
                Row["rel_grp"] = ENCODE(2, relgrp);
                Row["rel_sup"] = ENCODE(2, relsup);
                DataRow row = rq_workcd.Rows.Find(Row["workcd"].ToString());
                Row["work_addr"] = (row != null) ? row["work_addr"].ToString() : "";
            }
            return rq_dt;
        }

        public  void GetYrinsur1(DataTable dt_yrinsur, DataTable dt_dt)
        {
            int rowcnt = 0;
            dt_yrinsur.PrimaryKey = new DataColumn[] { dt_yrinsur.Columns["nobr"] };
            DataRow[] SRow = dt_dt.Select("rel_hel > 0", "nobr,fa_idno asc");
            foreach (DataRow Row in SRow)
            {
                DataRow row = dt_yrinsur.Rows.Find(Row["nobr"].ToString());
                if (row != null)
                {
                    if (rowcnt < 6)
                    {
                        row["fa_name" + rowcnt] = Row["fa_name"].ToString();
                        row["fa_idno" + rowcnt] = Row["fa_idno"].ToString();
                        row["fa_hamt" + rowcnt] = int.Parse(Row["rel_hel"].ToString());
                        row["fa_supamt" + rowcnt] = int.Parse(Row["rel_sup"].ToString());
                    }
                    row["totalamt"] = int.Parse(row["totalamt"].ToString()) + int.Parse(Row["rel_hel"].ToString()) + int.Parse(Row["rel_sup"].ToString());
                }
                else
                {
                    DataRow aRow = dt_yrinsur.NewRow();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["name_c"] = Row["name_c"].ToString();
                    aRow["name_e"] = Row["name_e"].ToString();
                    aRow["dept"] = Row["dept"].ToString();
                    aRow["d_name"] = Row["d_name"].ToString();
                    aRow["depts"] = Row["depts"].ToString();
                    aRow["idno"] = Row["idno"].ToString();
                    aRow["work_addr"] = Row["work_addr"].ToString();
                    aRow["insname"] = Row["insname"].ToString();
                    aRow["insman"] = Row["insman"].ToString();
                    aRow["insaddr"] = Row["insaddr"].ToString();
                    aRow["instel"] = Row["instel"].ToString();
                    aRow["h_amt"] = int.Parse(Row["rel_hel"].ToString());
                    aRow["l_amt"] = int.Parse(Row["rel_lab"].ToString());
                    aRow["sup_amt"] = int.Parse(Row["rel_sup"].ToString());
                    aRow["totalamt"] = int.Parse(Row["rel_lab"].ToString()) + int.Parse(Row["rel_hel"].ToString()) + int.Parse(Row["rel_sup"].ToString());
                    dt_yrinsur.Rows.Add(aRow);
                }
                rowcnt = rowcnt + 1;
            }
        }

        public  void GetYrinsur2(DataTable dt_yrinsur, DataTable dt_dt)
        {
            int rowcnt = 0;
            dt_yrinsur.PrimaryKey = new DataColumn[] { dt_yrinsur.Columns["nobr"] };
            DataRow[] SRow = dt_dt.Select("rel_grp > 0");
            foreach (DataRow Row in SRow)
            {
                DataRow row = dt_yrinsur.Rows.Find(Row["nobr"].ToString());
                int faidno = Row["fa_idno"].ToString().Trim().Length;
                if (row != null)
                {
                    if (rowcnt < 9)
                    {
                        row["fa_name" + rowcnt] = Row["fa_name"].ToString();
                        if (faidno == 10)
                            row["fa_idno" + rowcnt] = Row["fa_idno"].ToString().Substring(0, 4) + "****" + Row["fa_idno"].ToString().Substring(8, 2);
                        else if (faidno >= 8 && faidno <= 9)
                            row["fa_idno" + rowcnt] = Row["fa_idno"].ToString().Substring(0, 4) + "****" + Row["fa_idno"].ToString().Substring(8, faidno - 8);
                        row["g_amt" + rowcnt] = int.Parse(Row["rel_grp"].ToString());
                        row["rel_name" + rowcnt] = Row["rel_name"].ToString();
                        row["note" + rowcnt] = "";
                        if (rowcnt != 8) row["note" + (rowcnt + 1)] = "以下空白";
                    }
                    row["totalamt"] = int.Parse(row["totalamt"].ToString()) + int.Parse(Row["rel_grp"].ToString());
                }
                else
                {
                    DataRow aRow = dt_yrinsur.NewRow();
                    aRow["insname"] = Row["insname"].ToString().Trim();
                    aRow["nobr"] = Row["nobr"].ToString();
                    aRow["name_c"] = Row["name_c"].ToString().Trim();
                    aRow["name_e"] = Row["name_e"].ToString().Trim();
                    aRow["dept"] = Row["depts"].ToString();
                    //aRow["d_name"] = Row["d_name"].ToString();
                    //aRow["depts"] = Row["depts"].ToString();
                    if (Row["fa_idno"].ToString().Trim() == "")
                    {
                        aRow["fa_name"] = Row["name_c"].ToString().Trim();
                        aRow["idno"] = Row["idno"].ToString().Substring(0, 4) + "****" + Row["idno"].ToString().Substring(8, 2);
                        aRow["rel_name"] = "本人";
                    }
                    else
                    {
                        aRow["fa_name"] = Row["fa_name"].ToString().Trim();
                        if (faidno == 10)
                            aRow["idno"] = Row["fa_idno"].ToString().Substring(0, 4) + "****" + Row["fa_idno"].ToString().Substring(8, 2);
                        else if (faidno >= 8 && faidno <= 9)
                            aRow["idno"] = Row["fa_idno"].ToString().Substring(0, 4) + "****" + Row["fa_idno"].ToString().Substring(8, faidno - 8);
                        aRow["rel_name"] = Row["rel_name"].ToString().Trim();
                    }

                    aRow["g_amt"] = int.Parse(Row["rel_grp"].ToString());

                    aRow["note1"] = "以下空白";
                    aRow["totalamt"] = int.Parse(Row["rel_grp"].ToString());
                    dt_yrinsur.Rows.Add(aRow);
                }
                rowcnt = rowcnt + 1;
            }
        }
    }
}