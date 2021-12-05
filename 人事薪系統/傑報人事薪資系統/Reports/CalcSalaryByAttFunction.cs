/* ======================================================================================================
 * 功能名稱：
 * 功能代號：CalcSalaryByAttFunction
 * 功能路徑：
 * 檔案路徑：~\Customer\JBHR2\人事薪系統\傑報人事薪資系統\Reports\CalcSalaryByAttFunction.cs
 * 功能用途：
 *  用於產出員工出勤明細表
 */
/* 版本記錄：
 * ======================================================================================================
 *    日期           人員               版本              單號              說明
 * ------------------------------------------------------------------------------------------------------
 * 2021/11/26    Daniel Chih        Ver 1.0.01    20211126-DC0492-01    1. 增加【部門匯總（全勤獎金）】的全勤獎金 SalCode 代入
 * 
 * 
 */
/* ======================================================================================================
 *
 * 最後修改：Daniel Chih (0492) - 2021/11/26
 */

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using Microsoft.CSharp;
namespace JBModule.Data
{
    public class CalcSalaryByAttFunction
    {

        string SEQ;
        string NOBR_B;
        string NOBR_E;
        string DEPT_B;
        string DEPT_E;
        string Type;
        DateTime DATE_B;
        DateTime DATE_E;
        DateTime ATT_DATE_B;
        DateTime ATT_DATE_E;
        DateTime TRANS_DATE;
        DateTime InEDate;
        string SALADR;
        string YYMM;
        Dictionary<string, decimal> FullAttAmt;
        public  Dictionary<string ,decimal>     SalAttFunction(string yymm,
            string nobr_b, string nobr_e, string dept_b, string dept_e,
           DateTime AttDateB, DateTime AttDateE, string attawardsalcode
            )
        {

            JBModule.Data.CalcSalaryByFunction calcSalary = new JBModule.Data.CalcSalaryByFunction();
            JBHR.Sal.SalaryMDDataContext db = new JBHR.Sal.SalaryMDDataContext();
            this.YYMM = yymm;
            this.NOBR_B = nobr_b;
            this.NOBR_E = nobr_e;
            this.ATT_DATE_B = AttDateB;
            this.ATT_DATE_E = AttDateE;
            this.DATE_B  = AttDateB;
            this.DATE_E  = AttDateE;
            this.DEPT_B = dept_b;
            this.DEPT_E = dept_e;

            FullAttAmt = new Dictionary<string, decimal>();
            var sql = from a in db.BASE
                      join b in db.BASETTS on a.NOBR equals b.NOBR
                      join c in db.DEPT on b.DEPT equals c.D_NO
                      join b1 in db.BASETTS on a.NOBR equals b1.NOBR
                      join d in db.WriteRuleTable(JBHR.MainForm.USER_ID, JBHR.MainForm.COMPANY, JBHR.MainForm.ADMIN) on a.NOBR equals d.NOBR
                      //join wrnt in db.WriteRuleNobrTable.Where(p => p.GUID == guid) on a.NOBR equals wrnt.EMPID
                      where DATE_E >= b.ADATE && DATE_E <= b.DDATE
                      && c.D_NO_DISP.CompareTo(DEPT_B) >= 0 && c.D_NO_DISP.CompareTo(DEPT_E) <= 0
                      && b.NOBR.CompareTo(NOBR_B) >= 0 && b.NOBR.CompareTo(NOBR_E) <= 0
                      && new string[] { "1", "4", "6" }.Contains(b1.TTSCODE)
                      && (DATE_E >= b1.ADATE && b1.DDATE >= DATE_B
                        || ATT_DATE_E >= b1.ADATE && b1.DDATE >= ATT_DATE_B) //包含當月離離人員
                      select new { a.NOBR, a.NAME_C, b.SALADR };

            //FullAttAmt = new Dictionary<string, decimal>();
            //var sql = from a in db.BASE
            //          join b in db.BASETTS on new { a.NOBR } equals new { b.NOBR }
            //          join c in db.DEPT on b.DEPT equals c.D_NO
            //          join b1 in db.BASETTS on a.NOBR equals b1.NOBR
            //          join d in db.WriteRuleTable(JBHR.MainForm.USER_ID, JBHR.MainForm.COMPANY, JBHR.MainForm.ADMIN) on a.NOBR equals d.NOBR
            //          //join wrnt in db.WriteRuleNobrTable.Where(p => p.GUID == guid) on a.NOBR equals wrnt.EMPID
            //          where DATE_E >= b.ADATE && DATE_E <= b.DDATE
            //          && c.D_NO_DISP.CompareTo(DEPT_B) >= 0 
            //          && c.D_NO_DISP.CompareTo(DEPT_E) <= 0
            //          && b.NOBR.Equals(NOBR_B)
            //          && new string[] { "1", "4", "6" }.Contains(b1.TTSCODE)
            //          && (DATE_E >= b1.ADATE && b1.DDATE >= DATE_B
            //            || ATT_DATE_E >= b1.ADATE && b1.DDATE >= ATT_DATE_B) //包含當月離離人員
            //          select new { a.NOBR, a.NAME_C, b.SALADR };

            if (!sql.Any()) return FullAttAmt;
            
            

            foreach (var Emp in sql.Distinct())
             {
                var list = calcSalary.GetCalcSalaryMsg("SAL", Emp.NOBR, YYMM, ATT_DATE_B, ATT_DATE_E, DATE_B, DATE_E, JBHR.MainForm.USER_ID, JBHR.MainForm.COMPANY, JBHR.MainForm.ADMIN);
                //需求單號：20211126-DC0492-01
                foreach (var itm in list.Where(p => p.Salcode == attawardsalcode))
                {
                    FullAttAmt.Add(itm.Nobr, itm.Amt); 
                    //setProgress(0, string.Format("薪資公式計算_{0}", Emp.NOBR));
                    //WAGED waged = new WAGED();
                    //waged.AMT = JBModule.Data.CEncrypt.Number(itm.Amt);
                    //waged.NOBR = itm.Nobr;
                    //waged.SAL_CODE = itm.Salcode;
                    //waged.SEQ = SEQ;
                    //waged.YYMM = YYMM;
                    //InsertWaged(waged);
                };
            }
            return FullAttAmt;


        }

        public List<Dto.CalcSalaryMsgDto> GetCalcSalaryMsg(string CalcType, string Nobr, string Yymm, DateTime attDateB, DateTime attDateE, DateTime salDateB, DateTime salDateE, string UserId, string Comp, bool Admin)
        {

            List<Dto.CalcSalaryMsgDto> calcMsgList = new List<Dto.CalcSalaryMsgDto>();
            DateTime bdate = DateTime.Now;
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();


            var sql = from b in db.SALCODE
                      join c in db.SALFUNCTION on b.CAL_TYPE equals c.AUTO.ToString()
                      where c != null
                      && db.GetCodeFilter("SALCODE", b.SAL_CODE, UserId, Comp, Admin).Value
                      select new { 工號 = "", 薪資代碼 = b.SAL_CODE, 薪資名稱 = b.SAL_NAME, 項目 = c.ITEM, 金額 = "", 公式 = c.SCRIPT };

            var RefDic = GetRefValue(CalcType, Nobr, attDateB, attDateE, salDateB, salDateE, Yymm);
            Microsoft.JScript.Vsa.VsaEngine Engine = Microsoft.JScript.Vsa.VsaEngine.CreateEngine();


            foreach (var item in sql)
            {
                object reslut = null;
                var cont = item.公式;
                decimal defDecimal = 0;
                try
                {
                    cont = TransString(ref RefDic, cont);
                    reslut = Microsoft.JScript.Eval.JScriptEvaluate(cont, Engine);
                }
                catch { }
                Dto.CalcSalaryMsgDto row = new Dto.CalcSalaryMsgDto();
                row.Nobr = Nobr;
                row.Salcode = item.薪資代碼;
                row.SalName = item.薪資名稱;
                row.Yymm = Yymm;
                row.Amt = reslut == null ? 0M : Decimal.TryParse(reslut.ToString(), out defDecimal) ? Convert.ToDecimal(reslut) : 0M;
                row.Function = cont;
                calcMsgList.Add(row);
            }
            return calcMsgList;
        }

        public List<Dto.CalcAttendMsgDto> GetCalcAttMsg(string CalcType, string Nobr, DateTime attDateB, string RoteBonus)
        {

            List<Dto.CalcAttendMsgDto> calcMsgList = new List<Dto.CalcAttendMsgDto>();
            DateTime bdate = DateTime.Now;
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();


            var sql = from b in db.ROTE_BONUS
                      join c in db.SALFUNCTION on b.SALFUNCTION equals c.AUTO.ToString()
                      where b.AUTO.ToString() == RoteBonus && c != null
                      select new { Nobr = "", RoteBonus = b.AUTO.ToString(), Rote = b.ROTE, RoteName = b.ROTE1.ROTENAME, Salcode = b.SAL_CODE, SalName = b.SALCODE.SAL_NAME, Item = c.ITEM, Amt = "", Function = c.SCRIPT, ckAtt = b.CHECK4, ckOt = b.CHECK5 };

            var RefDic = GetRefValue(CalcType, Nobr, attDateB, attDateB, attDateB, attDateB, "");
            Microsoft.JScript.Vsa.VsaEngine Engine = Microsoft.JScript.Vsa.VsaEngine.CreateEngine();


            foreach (var item in sql)
            {
                object reslut = null;
                var cont = item.Function;
                decimal defDecimal = 0;
                try
                {
                    cont = TransString(ref RefDic, cont);
                    reslut = Microsoft.JScript.Eval.JScriptEvaluate(cont, Engine);
                }
                catch { }
                Dto.CalcAttendMsgDto row = new Dto.CalcAttendMsgDto();
                row.Nobr = Nobr;
                row.Bdate = attDateB;
                row.Rote = item.Rote;
                row.RoteName = item.RoteName;
                row.Salcode = item.Salcode;
                row.SalName = item.SalName;
                row.Amt = reslut == null ? 0M : Decimal.TryParse(reslut.ToString(), out defDecimal) ? Convert.ToDecimal(reslut) : 0M;
                row.Function = cont;
                row.FunctionName = item.Item;
                row.checkAtt = item.ckAtt;
                row.checkOt = item.ckOt;
                calcMsgList.Add(row);
            }
            return calcMsgList;
        }
        public List<Dto.CalcAttendMsgDto> GetCalcOtMsg(string CalcType, string Nobr, DateTime attDateB, string Btime, string Etime, string RoteBonus)
        {

            List<Dto.CalcAttendMsgDto> calcMsgList = new List<Dto.CalcAttendMsgDto>();
            DateTime bdate = DateTime.Now;
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();


            var sql = from b in db.ROTE_BONUS
                      join c in db.SALFUNCTION on b.SALFUNCTION equals c.AUTO.ToString()
                      where b.AUTO.ToString() == RoteBonus && c != null
                      select new { Nobr = "", RoteBonus = b.AUTO.ToString(), Rote = b.ROTE, RoteName = b.ROTE1.ROTENAME, Salcode = b.SAL_CODE, SalName = b.SALCODE.SAL_NAME, Item = c.ITEM, RoteBounsAmt = b.AMT, Function = c.SCRIPT, ckAtt = b.CHECK4, ckOt = b.CHECK5 };

            var RefDic = GetRefValue(CalcType, Nobr, attDateB, attDateB, attDateB, attDateB, "");
            Microsoft.JScript.Vsa.VsaEngine Engine = Microsoft.JScript.Vsa.VsaEngine.CreateEngine();


            foreach (var item in sql)
            {
                object reslut = null;
                var cont = item.Function;
                decimal defDecimal = 0;
                try
                {
                    cont = TransString(ref RefDic, cont);
                    reslut = Microsoft.JScript.Eval.JScriptEvaluate(cont, Engine);
                }
                catch { }
                Dto.CalcAttendMsgDto row = new Dto.CalcAttendMsgDto();
                row.Nobr = Nobr;
                row.Bdate = attDateB;
                row.Btime = Btime;
                row.Etime = Etime;
                row.Rote = item.Rote;
                row.RoteName = item.RoteName;
                row.Salcode = item.Salcode;
                row.SalName = item.SalName;
                row.Amt = reslut == null ? 0M : Decimal.TryParse(reslut.ToString(), out defDecimal) ? Convert.ToDecimal(reslut) : 0M;
                if (item.RoteBounsAmt != 0 && row.Amt != 0) row.Amt = item.RoteBounsAmt;
                row.Function = cont;
                row.FunctionName = item.Item;
                row.checkAtt = item.ckAtt;
                row.checkOt = item.ckOt;
                calcMsgList.Add(row);
            }
            return calcMsgList;
        }
        string SetInScript(string ColumnName, List<string> StrList)
        {
            string str = "";
            foreach (var item in StrList)
            {
                if (item != StrList.First())
                    str += ", ";
                str += string.Format("'{0}'", item);
            }
            str = string.Format("{0} IN ({1})", ColumnName, str);
            if (!StrList.Any()) str = "1 = 0";
            return str;
        }
        public string TransQuery(string Nobr, List<string> StrList, DateTime salEDate)
        {
            JBModule.Data.Linq.HrDBDataContext db = new Linq.HrDBDataContext();
            string str = "''";
            if (StrList.Count > 0)
            {
                str = string.Format("DECLARE @salcode nvarchar(50) set @salcode = '' select top 1 @salcode = SAL_CODE from SALBASD where dbo.DECODE(AMT)>0 and NOBR ='{0}' and {1} and '{2}' between ADATE and DDATE select @salcode", Nobr, SetInScript("SAL_CODE", StrList), salEDate.ToShortDateString());
                try
                {
                    str = string.Format("'{0}'", GetSqlQueryValue(db, str));
                }
                catch { }
            }
            return str;
        }
        public Dictionary<string, string> GetRefValue(string CalcType, string Nobr, DateTime attDateB, DateTime attDateE, DateTime salDateB, DateTime salDateE, string Yymm)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var sqlBaseByCalcType = db.SALBASE.Where(p => p.CALCTYPE == CalcType);

            var sqlBaseByBase = from a in db.SALCODE
                                join m in db.MTCODE on a.SALBASE equals m.CODE
                                //join c in db.SALBASE on a.SALBASE equals c.AUTO.ToString()
                                where m.CATEGORY == "CALC_REF_TYPE"
                                group new { m.NAME, a.SAL_CODE } by m.NAME;
            var sqlFunction = from a in db.SALFUNCTION
                              where a.CALCTYPE == CalcType
                              select a;

            //參數值
            Dictionary<string, string> Ref = new Dictionary<string, string>();
            Dictionary<string, string> RefBase = new Dictionary<string, string>();
            //參數轉換為值
            Dictionary<string, string> RefValue = new Dictionary<string, string>();
            ////固定取代的運算值
            Dictionary<string, string> Repdic = new Dictionary<string, string>();
            Repdic.Add("{CalcNobr}", Nobr);
            Repdic.Add("{CalcYymm}", Yymm);
            Repdic.Add("{CalcAttDateB}", attDateB.ToShortDateString());
            Repdic.Add("{CalcAttDateE}", attDateE.ToShortDateString());
            Repdic.Add("{CalcSalDateB}", salDateB.ToShortDateString());
            Repdic.Add("{CalcSalDateE}", salDateE.ToShortDateString());
            foreach (var item in sqlBaseByBase)
            {
                Repdic.Add("{" + item.Key + "}", TransQuery(Nobr, item.Select(p => p.SAL_CODE).ToList(), salDateE));
            }
            foreach (var item in sqlBaseByCalcType)
            {//處理參數方法
                string newStr = item.REFFUNCTION;

                //int v1 = newStr.IndexOf('%');//取第一個'%'位子
                //int lgh2 = newStr.IndexOf('%', v1 + 1) - v1 + 1;//取第二個'%'位子
                //newStr = newStr.Replace(newStr.Substring(v1, lgh2), string.Format("({0})", Repdic[newStr.Substring(v1, lgh2)]));
                foreach (var it in Repdic)
                {
                    newStr = newStr.Replace(it.Key, it.Value);
                }
                //newStr = GetSqlQueryValue(db, newStr);
                Ref.Add(string.Format("%{0}%", item.SALNAME), newStr);
            }
            foreach (var item in Ref)
            {
                string value = "";
                value = item.Value.ToString();
                while (value.Contains('%'))
                {
                    int v1 = value.IndexOf('%');//取第一個'%'位子
                    int lgh2 = value.IndexOf('%', v1 + 1) - v1 + 1;//取第二個'%'位子
                    value = value.Replace(value.Substring(v1, lgh2), string.Format("({0})", Ref[value.Substring(v1, lgh2)]));
                    //foreach (var itt in Ref)
                    //{
                    //    value = value.Replace(itt.Key, string.Format("({0})", itt.Value));
                    //}
                }
                //value = GetSqlQueryValue(db, value);

                RefValue.Add(item.Key, value);
            }
            Microsoft.JScript.Vsa.VsaEngine Engine = Microsoft.JScript.Vsa.VsaEngine.CreateEngine();
            Dictionary<string, string> func = new Dictionary<string, string>();
            foreach (var item in sqlFunction.Where(p => p.REF))
            {
                decimal defDecimal = 0;
                object reslut = null;
                var cont = item.SCRIPT;
                try
                {
                    cont = TransString(ref RefValue, cont);
                    reslut = Microsoft.JScript.Eval.JScriptEvaluate(cont, Engine);
                    var Amt = reslut == null ? 0M : Decimal.TryParse(reslut.ToString(), out defDecimal) ? Convert.ToDecimal(reslut) : 0M;
                    RefValue.Add(string.Format("%{0}%", item.ITEM), reslut.ToString());
                }
                catch { }

            }

            return RefValue;
        }

        public Dictionary<string, string> GetRefValue(string CalcType)
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            var sqlBaseByCalcType = db.SALBASE.Where(p => p.CALCTYPE == CalcType);
            var sqlFunction = from a in db.SALFUNCTION
                              where a.CALCTYPE == CalcType
                              select a;
            //參數值
            Dictionary<string, string> Ref = new Dictionary<string, string>();
            Dictionary<string, string> RefBase = new Dictionary<string, string>();
            //參數轉換為值
            Dictionary<string, string> RefValue = new Dictionary<string, string>();
            foreach (var item in sqlBaseByCalcType)
            {//處理參數方法
                string newStr = item.REFFUNCTION;
                Ref.Add(string.Format("%{0}%", item.SALNAME), newStr);
            }
            foreach (var item in Ref)
            {
                string value = "";
                value = item.Value.ToString();
                while (value.Contains('%'))
                {
                    int v1 = value.IndexOf('%');//取第一個'%'位子
                    int lgh2 = value.IndexOf('%', v1 + 1) - v1 + 1;//取第二個'%'位子
                    value = value.Replace(value.Substring(v1, lgh2), string.Format("({0})", Ref[value.Substring(v1, lgh2)]));
                }
                RefValue.Add(item.Key, value);
            }
            foreach (var item in sqlFunction.Where(p => p.REF))
            {
                string value = item.SCRIPT;
                while (value.Contains('%'))
                {
                    int v1 = value.IndexOf('%');//取第一個'%'位子
                    int lgh2 = value.IndexOf('%', v1 + 1) - v1 + 1;//取第二個'%'位子
                    value = value.Replace(value.Substring(v1, lgh2), string.Format("({0})", Ref[value.Substring(v1, lgh2)]));
                }
                RefValue.Add("%" + item.ITEM + "%", value);
            }

            return RefValue;
        }


        public string GetSqlQueryValue(JBModule.Data.Linq.HrDBDataContext db, string newStr)
        {
            if (!newStr.ToUpper().Contains("SELECT")) return newStr;
            if (newStr.ToUpper().Contains("%")) return newStr;
            //try { newStr = db.ExecuteQuery<string>(newStr).First().ToString(); }
            //catch
            //{
            //    try { newStr = db.ExecuteQuery<decimal>(newStr).First().ToString(); }
            //    catch
            //    {
            //        try { newStr = db.ExecuteQuery<int>(newStr).First().ToString(); }
            //        catch
            //        {
            //            try { newStr = db.ExecuteQuery<bool>(newStr).First().ToString(); }
            //            catch {
            //                try { newStr = "'" + db.ExecuteQuery<DateTime>(newStr).First().ToString("yyyy-MM-dd hh:mm:ss") + "'"; }
            //                catch
            //                {
            //                }
            //            }
            //        }
            //    }
            //}

            var cnSrt = ConfigurationManager.ConnectionStrings["JBHR.Properties.Settings.JBHRConnectionString"].ConnectionString;
            using (var conn = new SqlConnection(cnSrt))
            {
                conn.Open();

                var result = conn.Query(newStr).FirstOrDefault();
                if (result != null)
                {
                    foreach (var item in result)
                    {
                        newStr = string.Format("{0}", item.Value);
                    }
                }
                else
                    return "0";
            }
            return newStr;
        }
        public string TransString(ref Dictionary<string, string> refDic, string script)
        {
            JBModule.Data.Linq.HrDBDataContext db = new Linq.HrDBDataContext();
            string cont = script;
            while (cont.Contains('%'))
            {
                int v1 = cont.IndexOf('%');//取第一個'%'位子
                int lgh2 = cont.IndexOf('%', v1 + 1) - v1 + 1;//取第二個'%'位子
                string newStr = cont.Substring(v1, lgh2);
                refDic[newStr] = GetSqlQueryValue(db, refDic[newStr]);
                cont = cont.Replace(newStr, refDic[newStr]);
            }

            //foreach (var item in refDic)
            //{
            //    cont = cont.Replace(string.Format("{0}", item.Key), item.Value.ToString());
            //}
            return cont;
        }

        public string TransString(string script, Dictionary<string, string> RefDic, Dictionary<string, string> Repdic, ref Dictionary<string, string> SalFuncParam)
        {
            JBModule.Data.Linq.HrDBDataContext db = new Linq.HrDBDataContext();
            string cont = script;

            while (cont.Contains('%'))
            {
                int v1 = cont.IndexOf('%');//取第一個'%'位子
                int lgh2 = cont.IndexOf('%', v1 + 1) - v1 + 1;//取第二個'%'位子
                string newStr = cont.Substring(v1, lgh2);
                string FinalStr = RefDic[newStr];
                SalFuncParam.Add(newStr, RefDic[newStr]);
                foreach (var it in Repdic)
                {
                    FinalStr = FinalStr.Replace(it.Key, it.Value);
                }
                FinalStr = GetSqlQueryValue(db, FinalStr);
                cont = cont.Replace(newStr, FinalStr);
            }
            return cont;
        }
        public string TransString(string script, Dictionary<string, string> RefDic, Dictionary<string, string> Repdic, Dictionary<string, string> SalFuncParam)
        {
            JBModule.Data.Linq.HrDBDataContext db = new Linq.HrDBDataContext();
            string cont = script;

            while (cont.Contains('%'))
            {
                int v1 = cont.IndexOf('%');//取第一個'%'位子
                int lgh2 = cont.IndexOf('%', v1 + 1) - v1 + 1;//取第二個'%'位子
                string newStr = cont.Substring(v1, lgh2);
                string FinalStr = SalFuncParam[newStr];
                FinalStr = GetSqlQueryValue(db, FinalStr);
                cont = cont.Replace(newStr, FinalStr);
            }
            return cont;
        }
    }
}
