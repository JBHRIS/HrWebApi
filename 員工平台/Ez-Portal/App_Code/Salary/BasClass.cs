using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Collections;
using System.Net.Mail;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using System.Reflection;

/// <summary>
/// BasClass 的摘要描述
/// </summary>
/// 
using BL.Salary;
using JBHR.Dll;
namespace Salary.Base
{
    
    public static class BasClass
	{
        //public static dsBas.JB_HR_BaseDataTable EmpBase(string sNobr)
        //{
        //    dcBasDataContext dc = new dcBasDataContext();
        //    //Salary.dcBasDataContext dc = new Salary.dcBasDataContext();            
        //    IQueryable<BL.Salary.JB_HR_Base> sql = from c in dc.JB_HR_Base select c;
        //    if (sNobr.Trim().Length > 0)
        //        sql = from c in dc.JB_HR_Base where c.sNobr.Trim() == sNobr.Trim() select c;
        //    DbCommand dr = dc.GetCommand(sql);
        //    dsBas.JB_HR_BaseDataTable dt = new dsBas.JB_HR_BaseDataTable();
        //    dt.FillData(dr);

        //    return dt;
        //}

         public static int ENCODE(int ENCODE_TYPE, int VALT)
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

         public static DataTable GetBase(string Snobr,string DateB)
         {
             SqlConnection Conn = null;
             SqlCommand Cmd = null;
             Conn = Salary.Base.BasClass.GetConn();
             Cmd = new SqlCommand();
             Cmd.Connection = Conn;
             DataTable rq_base = new DataTable();
             string Sql = "select b.nobr,a.name_c,a.name_e,c.d_no_disp as dept,c.d_name,b.indt,d.job_disp as job ,d.job_name";
             Sql += ",b.indt,b.retchoo";
             Sql += " from base a,basetts b ";
             Sql += " left outer join dept c on b.dept=c.d_no";
             Sql += " left outer join job d on b.job=d.job";
             Sql += string.Format(@" where b.nobr='{0}'", Snobr);
             Sql += string.Format(@" and '{0}' between b.adate and b.ddate", DateB);
             Sql += " and  a.nobr=b.nobr";
             Cmd.CommandText = Sql;
             SqlDataAdapter SCmd1a = new SqlDataAdapter(Cmd);
             SCmd1a.Fill(rq_base);
             return rq_base;
         }

         public static DataTable GetWaged(string Snobr, string YYmm, string Seq, DataTable rq_base)
         {
             SqlConnection Conn = null;
             SqlCommand Cmd = null;
             Conn = Salary.Base.BasClass.GetConn();
             Cmd = new SqlCommand();
             Cmd.Connection = Conn;
             DataTable rq_waged = new DataTable();

             string SqlCmd1 = "select b.nobr,b.sal_code,c.sal_code_disp,c.sal_name,b.amt,a.adate,a.account_no,d.flag,d.salattr";
             SqlCmd1 += ",d.tax,d.type,a.note,a.att_dateb,a.att_datee,wk_days";
             SqlCmd1 += " from  wage a,waged b ";
             SqlCmd1 += " left outer join salcode c on b.sal_code=c.sal_code";
             SqlCmd1 += " left outer join salattr d on c.sal_attr=d.salattr";
             SqlCmd1 += string.Format(@" where b.nobr='{0}' and b.yymm='{1}' and b.seq='{2}'", Snobr, YYmm, Seq);
             SqlCmd1 += " and a.nobr=b.nobr and a.yymm=b.yymm and a.seq=b.seq";
             SqlCmd1 += " order by b.nobr,c.sal_attr,c.sal_code_disp ";
             Cmd.CommandText = SqlCmd1;
             SqlDataAdapter SCmd1b = new SqlDataAdapter(Cmd);
             SCmd1b.Fill(rq_waged);
             rq_waged.Columns.Add("name_c", typeof(string));
             rq_waged.Columns.Add("dept", typeof(string));
             rq_waged.Columns.Add("d_name", typeof(string));
             rq_waged.Columns.Add("job", typeof(string));
             rq_waged.Columns.Add("job_name", typeof(string));
            
             rq_base.PrimaryKey = new DataColumn[] { rq_base.Columns["nobr"] };
             foreach (DataRow Row in rq_waged.Rows)
             {
                 DataRow row = rq_base.Rows.Find(Row["nobr"].ToString());                
                 if (row != null)
                 {
                     Row["name_c"] = row["name_c"].ToString();
                     Row["dept"] = row["dept"].ToString();
                     Row["d_name"] = row["d_name"].ToString();
                     Row["job"] = row["job"].ToString();
                     Row["job_name"] = row["job_name"].ToString();
                     if (Row["type"].ToString().Trim() == "4")
                         Row.Delete();
                 }
                 else
                     Row.Delete();
             }
             rq_waged.AcceptChanges();
             return rq_waged;
         }

         public static DataTable GetInslab(string Snobr, string DateB)
         {
             SqlConnection Conn = null;
             SqlCommand Cmd = null;
             Conn = Salary.Base.BasClass.GetConn();
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

         public static DataTable GetExplab(string Snobr, string YYmm)
         {
             SqlConnection Conn = null;
             SqlCommand Cmd = null;
             Conn = Salary.Base.BasClass.GetConn();
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

         public static DataTable GetOt(string Snobr, string YYmm)
         {
             SqlConnection Conn = null;
             SqlCommand Cmd = null;
             Conn = Salary.Base.BasClass.GetConn();
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

         public static void Get_Ot1(DataTable DT_ot, DataTable Dt_ota)
         {
             DataTable rq_otb = new DataTable();
             rq_otb.Columns.Add("nobr", typeof(string));
             rq_otb.Columns.Add("rate", typeof(decimal));
             rq_otb.Columns.Add("othrs", typeof(decimal));
             rq_otb.PrimaryKey = new DataColumn[] { rq_otb.Columns["nobr"], rq_otb.Columns["rate"] };
             foreach (DataRow Row in Dt_ota.Rows)
             {
                 if (Row["rote"].ToString().Trim() == "00")
                 {
                     DataRow rowt = DT_ot.Rows.Find(Row["nobr"].ToString());
                     if (rowt != null)
                         rowt["ot_200_h"] = decimal.Parse(rowt["ot_200_h"].ToString()) + decimal.Parse(Row["ot_hrs"].ToString());
                     else
                     {
                         DataRow aRowt = DT_ot.NewRow();
                         aRowt["nobr"] = Row["nobr"].ToString();
                         aRowt["ot_100"] = 0;
                         aRowt["ot_133"] = 0;
                         aRowt["ot_150"] = 0;
                         aRowt["ot_167"] = 0;
                         aRowt["ot_200"] = 0;
                         aRowt["ot_200_h"] = decimal.Parse(Row["ot_hrs"].ToString());
                         aRowt["ot_250_h"] = 0;
                         DT_ot.Rows.Add(aRowt);
                     }
                 }
                 else
                 {
                     if (decimal.Parse(Row["nop_w_100"].ToString()) > 0)
                     {
                         object[] _value = new object[2];
                         _value[0] = Row["nobr"].ToString();
                         _value[1] = decimal.Parse(Row["nop_w_100"].ToString());
                         DataRow row = rq_otb.Rows.Find(_value);
                         if (row != null)
                             row["othrs"] = decimal.Parse(row["othrs"].ToString()) + decimal.Parse(Row["not_w_100"].ToString());
                         else
                         {
                             DataRow aRow = rq_otb.NewRow();
                             aRow["nobr"] = Row["nobr"].ToString();
                             aRow["rate"] = decimal.Parse(Row["nop_w_100"].ToString());
                             aRow["othrs"] = decimal.Parse(Row["not_w_100"].ToString());
                             rq_otb.Rows.Add(aRow);
                         }
                     }
                     if (decimal.Parse(Row["nop_w_133"].ToString()) > 0)
                     {
                         object[] _value = new object[2];
                         _value[0] = Row["nobr"].ToString();
                         _value[1] = decimal.Parse(Row["nop_w_133"].ToString());
                         DataRow row = rq_otb.Rows.Find(_value);
                         if (row != null)
                         {
                             row["othrs"] = decimal.Parse(row["othrs"].ToString()) + decimal.Parse(Row["not_w_133"].ToString());
                             row["othrs"] = decimal.Parse(row["othrs"].ToString()) + decimal.Parse(Row["tot_w_133"].ToString());
                         }
                         else
                         {
                             DataRow aRow = rq_otb.NewRow();
                             aRow["nobr"] = Row["nobr"].ToString();
                             aRow["rate"] = decimal.Parse(Row["nop_w_133"].ToString());
                             aRow["othrs"] = decimal.Parse(Row["not_w_133"].ToString());
                             aRow["othrs"] = decimal.Parse(aRow["othrs"].ToString()) + decimal.Parse(Row["tot_w_133"].ToString());
                             rq_otb.Rows.Add(aRow);
                         }
                     }
                     if (decimal.Parse(Row["nop_w_167"].ToString()) > 0)
                     {
                         object[] _value = new object[2];
                         _value[0] = Row["nobr"].ToString();
                         _value[1] = decimal.Parse(Row["nop_w_167"].ToString());
                         DataRow row = rq_otb.Rows.Find(_value);
                         if (row != null)
                         {
                             row["othrs"] = decimal.Parse(row["othrs"].ToString()) + decimal.Parse(Row["not_w_167"].ToString());
                             row["othrs"] = decimal.Parse(row["othrs"].ToString()) + decimal.Parse(Row["tot_w_167"].ToString());
                         }
                         else
                         {
                             DataRow aRow = rq_otb.NewRow();
                             aRow["nobr"] = Row["nobr"].ToString();
                             aRow["rate"] = decimal.Parse(Row["nop_w_167"].ToString());
                             aRow["othrs"] = decimal.Parse(Row["not_w_167"].ToString());
                             aRow["othrs"] = decimal.Parse(aRow["othrs"].ToString()) + decimal.Parse(Row["tot_w_167"].ToString());
                             rq_otb.Rows.Add(aRow);
                         }
                     }
                     if (decimal.Parse(Row["nop_w_200"].ToString()) > 0)
                     {
                         object[] _value = new object[2];
                         _value[0] = Row["nobr"].ToString();
                         _value[1] = decimal.Parse(Row["nop_w_200"].ToString());
                         DataRow row = rq_otb.Rows.Find(_value);
                         if (row != null)
                         {
                             row["othrs"] = decimal.Parse(row["othrs"].ToString()) + decimal.Parse(Row["not_w_200"].ToString());
                             row["othrs"] = decimal.Parse(row["othrs"].ToString()) + decimal.Parse(Row["tot_w_200"].ToString());
                         }
                         else
                         {
                             DataRow aRow = rq_otb.NewRow();
                             aRow["nobr"] = Row["nobr"].ToString();
                             aRow["rate"] = decimal.Parse(Row["nop_w_200"].ToString());
                             aRow["othrs"] = decimal.Parse(Row["not_w_200"].ToString());
                             aRow["othrs"] = decimal.Parse(aRow["othrs"].ToString()) + decimal.Parse(Row["tot_w_200"].ToString());
                             rq_otb.Rows.Add(aRow);
                         }
                     }
                     if (decimal.Parse(Row["nop_h_133"].ToString()) > 0)
                     {
                         object[] _value = new object[2];
                         _value[0] = Row["nobr"].ToString();
                         _value[1] = decimal.Parse(Row["nop_h_133"].ToString());
                         DataRow row = rq_otb.Rows.Find(_value);
                         if (row != null)
                             row["othrs"] = decimal.Parse(row["othrs"].ToString()) + decimal.Parse(Row["not_h_133"].ToString());
                         else
                         {
                             DataRow aRow = rq_otb.NewRow();
                             aRow["nobr"] = Row["nobr"].ToString();
                             aRow["rate"] = decimal.Parse(Row["nop_h_133"].ToString());
                             aRow["othrs"] = decimal.Parse(Row["not_h_133"].ToString());
                             rq_otb.Rows.Add(aRow);
                         }
                     }
                     if (decimal.Parse(Row["nop_h_167"].ToString()) > 0)
                     {
                         object[] _value = new object[2];
                         _value[0] = Row["nobr"].ToString();
                         _value[1] = decimal.Parse(Row["nop_h_167"].ToString());
                         DataRow row = rq_otb.Rows.Find(_value);
                         if (row != null)
                             row["othrs"] = decimal.Parse(row["othrs"].ToString()) + decimal.Parse(Row["not_h_167"].ToString());
                         else
                         {
                             DataRow aRow = rq_otb.NewRow();
                             aRow["nobr"] = Row["nobr"].ToString();
                             aRow["rate"] = decimal.Parse(Row["nop_h_167"].ToString());
                             aRow["othrs"] = decimal.Parse(Row["not_h_167"].ToString());
                             rq_otb.Rows.Add(aRow);
                         }
                     }
                     if (decimal.Parse(Row["nop_h_200"].ToString()) > 0)
                     {
                         object[] _value = new object[2];
                         _value[0] = Row["nobr"].ToString();
                         _value[1] = decimal.Parse(Row["nop_h_200"].ToString());
                         DataRow row = rq_otb.Rows.Find(_value);
                         if (row != null)
                             row["othrs"] = decimal.Parse(row["othrs"].ToString()) + decimal.Parse(Row["not_h_200"].ToString());
                         else
                         {
                             DataRow aRow = rq_otb.NewRow();
                             aRow["nobr"] = Row["nobr"].ToString();
                             aRow["rate"] = decimal.Parse(Row["nop_h_200"].ToString());
                             aRow["othrs"] = decimal.Parse(Row["not_h_200"].ToString());
                             rq_otb.Rows.Add(aRow);
                         }
                     }
                 }
             }

             foreach (DataRow Row1 in rq_otb.Rows)
             {
                 DataRow row = DT_ot.Rows.Find(Row1["nobr"].ToString());
                 if (row != null)
                 {
                     if (decimal.Parse(Row1["rate"].ToString()) == decimal.Parse("1.00"))
                         row["ot_100"] = decimal.Parse(row["ot_100"].ToString()) + decimal.Parse(Row1["othrs"].ToString());
                     else if (decimal.Parse(Row1["rate"].ToString()) == decimal.Parse("1.34"))
                         row["ot_133"] = decimal.Parse(row["ot_133"].ToString()) + decimal.Parse(Row1["othrs"].ToString());
                     else if (decimal.Parse(Row1["rate"].ToString()) == decimal.Parse("1.5"))
                         row["ot_150"] = decimal.Parse(row["ot_150"].ToString()) + decimal.Parse(Row1["othrs"].ToString());
                     else if (decimal.Parse(Row1["rate"].ToString()) == decimal.Parse("1.67"))
                         row["ot_167"] = decimal.Parse(row["ot_167"].ToString()) + decimal.Parse(Row1["othrs"].ToString());
                     else if (decimal.Parse(Row1["rate"].ToString()) == decimal.Parse("2.00"))
                         row["ot_200"] = decimal.Parse(row["ot_200"].ToString()) + decimal.Parse(Row1["othrs"].ToString());
                 }
                 else
                 {
                     DataRow aRow = DT_ot.NewRow();
                     aRow["nobr"] = Row1["nobr"].ToString();
                     aRow["ot_100"] = 0;
                     aRow["ot_133"] = 0;
                     aRow["ot_150"] = 0;
                     aRow["ot_167"] = 0;
                     aRow["ot_200"] = 0;
                     aRow["ot_200_h"] = 0;
                     aRow["ot_250_h"] = 0;
                     if (decimal.Parse(Row1["rate"].ToString()) == decimal.Parse("1.00"))
                         aRow["ot_100"] = decimal.Parse(Row1["othrs"].ToString());
                     else if (decimal.Parse(Row1["rate"].ToString()) == decimal.Parse("1.34"))
                         aRow["ot_133"] = decimal.Parse(Row1["othrs"].ToString());
                     else if (decimal.Parse(Row1["rate"].ToString()) == decimal.Parse("1.5"))
                         aRow["ot_150"] = decimal.Parse(Row1["othrs"].ToString());
                     else if (decimal.Parse(Row1["rate"].ToString()) == decimal.Parse("1.67"))
                         aRow["ot_167"] = decimal.Parse(Row1["othrs"].ToString());
                     else if (decimal.Parse(Row1["rate"].ToString()) == decimal.Parse("2.00"))
                         aRow["ot_200"] = decimal.Parse(Row1["othrs"].ToString());
                     DT_ot.Rows.Add(aRow);
                 }
             }
             rq_otb = null;
         }

         public static DataTable Get_Ret(string Snobr, string YYmm, string date_b)
         {
             SqlConnection Conn = null;
             SqlCommand Cmd = null;
             Conn = Salary.Base.BasClass.GetConn();
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

         public static DataTable Get_Attend(string Snobr, string attdate_b, string attdate_e)
         {
             SqlConnection Conn = null;
             SqlCommand Cmd = null;
             Conn = Salary.Base.BasClass.GetConn();
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
             return rq_attend;
         }

         public static DataTable Get_Abs(string Snobr, string YYmm)
         {
             //and b.att=1判斷是否只顯示影響全勤
             SqlConnection Conn = null;
             SqlCommand Cmd = null;
             Conn = Salary.Base.BasClass.GetConn();
             Cmd = new SqlCommand();
             Cmd.Connection = Conn;
             DataTable rq_abs = new DataTable();
             string Sql = "select a.nobr,b.h_code_disp as h_code,b.unit,b.h_name,sum(a.tol_hours) as tol_hours";
             Sql += "  from abs a,hcode b where a.h_code =b.h_code ";
             Sql += string.Format(@" and a.nobr = '{0}'", Snobr);
             Sql += string.Format(@" and a.yymm='{0}'", YYmm);
             Sql += " and  b.year_rest in('0','2','4') ";
             Sql += " group by a.nobr,b.h_code_disp,b.unit,b.h_name";
             Cmd.CommandText = Sql;
             SqlDataAdapter SCmd1a = new SqlDataAdapter(Cmd);
             SCmd1a.Fill(rq_abs);
             return rq_abs;
         }

         public static DataTable Get_Abs1(string Snobr, string date_e)
         {
            
             SqlConnection Conn = null;
             SqlCommand Cmd = null;
             Conn = Salary.Base.BasClass.GetConn();
             Cmd = new SqlCommand();
             Cmd.Connection = Conn;
             DataTable rq_abs = new DataTable();

             string Sql = "select a.nobr,b.htype,sum(a.balance) as tol_hours";
             Sql += "  from abs a,hcode b where a.h_code =b.h_code ";
             Sql += string.Format(@" and a.nobr = '{0}' ", Snobr);
             Sql += string.Format(@" and '{0}' between a.bdate and a.edate", date_e);
             Sql += " and b.htype between '1' and '2' and b.flag='+'  ";
             Sql += " group by a.nobr,b.htype";
             Cmd.CommandText = Sql;
             SqlDataAdapter SCmd1a = new SqlDataAdapter(Cmd);
             SCmd1a.Fill(rq_abs);

             DataTable rq_abs1 = new DataTable();
             rq_abs1.Columns.Add("nobr", typeof(string));
             rq_abs1.Columns.Add("leave_hrs", typeof(decimal));
             rq_abs1.Columns.Add("rest_hrs", typeof(decimal));
             rq_abs1.PrimaryKey = new DataColumn[] { rq_abs1.Columns["nobr"] };
             foreach (DataRow Row in rq_abs.Rows)
             {
                 string htype = Row["htype"].ToString().Trim();
                 DataRow row = rq_abs1.Rows.Find(Row["nobr"].ToString());
                 if (row != null)
                 {
                     if (htype == "1")
                         row["leave_hrs"] = decimal.Parse(row["leave_hrs"].ToString()) + decimal.Parse(Row["tol_hours"].ToString());
                     else if (htype == "2")
                         row["rest_hrs"] = decimal.Parse(row["rest_hrs"].ToString()) + decimal.Parse(Row["tol_hours"].ToString());                    
                 }
                 else
                 {
                     DataRow aRow = rq_abs1.NewRow();
                     aRow["nobr"] = Row["nobr"].ToString();
                     aRow["leave_hrs"] = 0;
                     aRow["rest_hrs"] = 0;
                     if (htype == "1")
                         aRow["leave_hrs"]= decimal.Parse(Row["tol_hours"].ToString());
                     else if (htype == "2")
                         aRow["rest_hrs"] = decimal.Parse(Row["tol_hours"].ToString());                    
                     rq_abs1.Rows.Add(aRow);
                 }
             }
             return rq_abs1;
         }



         public static void GetSalay(DataTable dt_salary, DataTable dt_waged, DataTable dt_ot, DataTable dt_abs,DataTable dt_abs1, DataTable dt_attend,DataTable dt_ret, string comp)
         {
             //勞退自提
             SqlConnection Conn = null;
             SqlCommand Cmd = null;
             Conn = Salary.Base.BasClass.GetConn();
             Cmd = new SqlCommand();
             Cmd.Connection = Conn;
             DataTable rq_retamt = new DataTable();
             string Sql = "select retsalcode,nretirerate from u_sys4 where comp='" + comp + "'";
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
                     aRow["dept"] = Row["dept"].ToString();
                     aRow["d_name"] = Row["d_name"].ToString();
                     aRow["account_no"] = Row["account_no"].ToString();
                     aRow["adate"] = DateTime.Parse(Row["adate"].ToString());
                     aRow["attdate_b"] = DateTime.Parse(Row["att_dateb"].ToString());
                     aRow["attdate_e"] = DateTime.Parse(Row["att_datee"].ToString());
                     aRow["job"] = Row["job"].ToString();
                     aRow["job_name"] = Row["job_name"].ToString();
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
                 for(int i=0;i< SRow.Length;i++)
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

                 DataRow row15 = dt_ot.Rows.Find(Row1["nobr"].ToString());
                 if (row15 != null)
                 {
                     if (decimal.Parse(row15["ot_133"].ToString()) != 0) Row1["ot_133"] = decimal.Parse(row15["ot_133"].ToString());
                     if (decimal.Parse(row15["ot_167"].ToString()) != 0) Row1["ot_167"] = decimal.Parse(row15["ot_167"].ToString());
                     if (decimal.Parse(row15["ot_150"].ToString()) != 0) Row1["ot_150"] = decimal.Parse(row15["ot_150"].ToString());
                     if (decimal.Parse(row15["ot_200"].ToString()) != 0) Row1["ot_200"] = decimal.Parse(row15["ot_200"].ToString());
                     if (decimal.Parse(row15["ot_200_h"].ToString()) != 0) Row1["ot_200h"] = decimal.Parse(row15["ot_200_h"].ToString());
                 }

                 //請假資料
                 DataRow[] row4 = dt_abs.Select("nobr='" + Row1["nobr"].ToString() + "'", "h_code asc");
                 for (int i = 0; i < row4.Length; i++)
                 {
                     Row1["Fldat" + (i + 1)] = row4[i]["h_name"].ToString();
                     Row1["Flda" + (i + 1)] = decimal.Parse(row4[i]["tol_hours"].ToString());
                     Row1["Fldau" + (i + 1)] = row4[i]["unit"].ToString();
                         
                 }
                 int _abscn = row4.Length + 1;
                 DataRow row5 = dt_attend.Rows.Find(Row1["nobr"].ToString());
                 if (row5 != null)
                 {
                     if (decimal.Parse(row5["late_mins"].ToString()) > 0)
                     {
                         Row1["Flda" + _abscn] = decimal.Round(decimal.Parse(row5["late_mins"].ToString()), 0);
                         Row1["Fldat" + _abscn] = "遲到";
                         Row1["Fldau" + _abscn] = "次";
                         _abscn++;
                     }
                     if (decimal.Parse(row5["forget"].ToString()) > 0)
                     {
                         Row1["Flda" + _abscn] = decimal.Round(decimal.Parse(row5["forget"].ToString()), 0);
                         Row1["Fldat" + _abscn] = "忘刷";
                         Row1["Fldau" + _abscn] = "次";                        
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
                     Row1["Fldd8"] = ENCODE(2, _exppamt);
                     
                 }

                 DataRow row9 = wagedsz.Rows.Find(Row1["nobr"].ToString());
                 if (row9 != null)
                 {
                     Row1["Flddt3"] = "實發金額";
                     Row1["Fldd3"] = int.Parse(row9["tot1"].ToString());
                 }

                 DataRow row10 = wageds1.Rows.Find(Row1["nobr"].ToString());
                 if (row10 != null)
                 {
                     Row1["Flddt1"] = "應稅薪資";
                     Row1["Fldd1"] = int.Parse(row10["tot1"].ToString());
                 }

                 DataRow row10a = wageds2.Rows.Find(Row1["nobr"].ToString());
                 if (row10a != null)
                 {
                     Row1["Flddt2"] = "應發薪資";
                     Row1["Fldd2"] = int.Parse(row10a["tot1"].ToString());
                 }

                 DataRow row12 = dt_abs1.Rows.Find(Row1["nobr"].ToString());
                 if (row12 != null)
                 {
                     Row1["leave_hrs"] = decimal.Parse(row12["leave_hrs"].ToString());
                     Row1["rest_hrs"] = decimal.Parse(row12["rest_hrs"].ToString());
                 }
             }
         }

         public static DataTable GetInJob(string Snobr)
         {
             SqlConnection Conn = null;
             SqlCommand Cmd = null;
             Conn = Salary.Base.BasClass.GetConn();
             Cmd = new SqlCommand();
             Cmd.Connection = Conn;
             DataTable rq_injob = new DataTable();
             string Sql = "select a.nobr,a.name_c,a.name_e,a.birdt,a.idno,DBO.GETTOTALYEARS(a.nobr,getdate()) as wk_yrs";
             Sql += ",c.d_no_disp as dept,c.d_name,d.job_disp as job,d.job_name,b.indt,b.oudt";
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

         public static DataTable GetSalBasd(string Snobr)
         {
             SqlConnection Conn = null;
             SqlCommand Cmd = null;
             Conn = Salary.Base.BasClass.GetConn();
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

         public static void GetYearSalay(DataTable dt_yearsalary,DataTable dt_salbasd, DataTable dt_base)
         { 
             dt_base.PrimaryKey=new DataColumn[]{dt_base.Columns["nobr"]};
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

         public static DataTable GetYrtax(string Snobr, string Year)
         {
             SqlConnection Conn = null;
             SqlCommand Cmd = null;
             Conn = Salary.Base.BasClass.GetConn();
             Cmd = new SqlCommand();
             Cmd.Connection = Conn;
             DataTable rq_yrtax = new DataTable();
             string Sql = "select e.d_no_disp as dept,e.d_name,e.d_ename,a.name_e,c.*";
             Sql += " from yrtax c,base a,basetts b";
             Sql += " left outer join dept e on b.dept=e.d_no";
             Sql += "  where c.nobr=b.nobr and a.nobr=b.nobr ";
             Sql += string.Format(@" and '{0}' between b.adate and b.ddate", Year + "/12/31");
             Sql += string.Format(@" and c.nobr='{0}'", Snobr);
             Sql += string.Format(@" and c.year='{0}'", Year);             
             Cmd.CommandText = Sql;
             SqlDataAdapter SCmd1a = new SqlDataAdapter(Cmd);
             SCmd1a.Fill(rq_yrtax);
             foreach (DataRow Row in rq_yrtax.Rows)
             {
                 int _totamt = (int)decimal.Parse(Row["tot_amt"].ToString());
                 int _relamt = (int)decimal.Parse(Row["rel_amt"].ToString());
                 int _taxamt = (int)decimal.Parse(Row["tax_amt"].ToString());
                 int _retamt = (int)decimal.Parse(Row["ret_amt"].ToString());
                 Row["nobr"] = Row["nobr"].ToString().Trim();
                 Row["tot_amt"] = ENCODE(2, _totamt);
                 Row["rel_amt"] = ENCODE(2, _relamt);
                 Row["tax_amt"] = ENCODE(2, _taxamt);
                 Row["ret_amt"] = ENCODE(2, _retamt);
             }
             return rq_yrtax;
         }

         public static DataTable GetComp(string Comp)
         {
             SqlConnection Conn = null;
             SqlCommand Cmd = null;
             Conn = Salary.Base.BasClass.GetConn();
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

         public static DataTable GetYrinsur(string Snobr, string Year)
         {
             SqlConnection Conn = null;
             SqlCommand Cmd = null;
             Conn = Salary.Base.BasClass.GetConn();
             Cmd = new SqlCommand();
             Cmd.Connection = Conn;
             DataTable rq_dt = new DataTable();
             string Sql = "select c.nobr,d.fa_idno,d.fa_birdt,d.fa_name,c.rel_lab,c.rel_hel,c.rel_grp,c.rel_sup,";
             Sql += "a.idno,a.name_c,a.name_e,b.dept,f.d_name,b.depts,b.workcd,d.fa_name";
             Sql += " from base a,basetts b,dept f,yrinsur c";
             Sql += " left outer join family d on c.fa_idno=d.fa_idno and c.nobr=d.nobr";             
             Sql += "  where c.nobr=b.nobr and a.nobr=b.nobr and b.depts=f.d_no";
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
                 int relsup = (int)decimal.Parse(Row["rel_sup"].ToString());
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

         public static void GetYrinsur1(DataTable dt_yrinsur, DataTable dt_dt)
         {
             int rowcnt = 0;
             dt_yrinsur.PrimaryKey = new DataColumn[] { dt_yrinsur.Columns["nobr"] };
             foreach (DataRow Row in dt_dt.Rows)
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
                     aRow["h_amt"] = int.Parse(Row["rel_hel"].ToString());
                     aRow["sup_amt"] = int.Parse(Row["rel_sup"].ToString());
                     aRow["totalamt"] = int.Parse(Row["rel_hel"].ToString())+ int.Parse(Row["rel_sup"].ToString());
                     dt_yrinsur.Rows.Add(aRow);
                 }
                 rowcnt = rowcnt + 1;
             }
         }

	}
}