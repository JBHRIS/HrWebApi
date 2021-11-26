using JBTools.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHR.Sal.Core
{
    public class RoteCalculation
    {
        List<JBModule.Data.Linq.ROTE_BONUS> roteBonusList = null;
        List<JBModule.Data.Linq.CALC_CONDITION> calcCondList = null;
        JBModule.Data.Linq.HrDBDataContext db = null;
        public RoteCalculation()
        {
            db = new JBModule.Data.Linq.HrDBDataContext();
            roteBonusList = db.ROTE_BONUS.ToList();
            calcCondList = db.CALC_CONDITION.ToList();
        }
        public OtBonusCalc CreateOtBonusCalc()
        {
            OtBonusCalc obc = new OtBonusCalc();
            obc.calcCondList = calcCondList.Where(p => p.SOURCE == "RoteBonusConditionType").ToList();
            obc.roteBonusList = roteBonusList.Where(p => p.CHECK5).ToList();
            return obc;
        }
        public OtBonusCalc CreateAttendBonusCalc()
        {
            OtBonusCalc obc = new OtBonusCalc();
            obc.calcCondList = calcCondList.Where(p => p.SOURCE == "RoteBonusConditionType").ToList();
            obc.roteBonusList = roteBonusList.Where(p => p.CHECK4).ToList();
            return obc;
        }
        public void CheckOtBonusConditionType()
        {
            Dictionary<string, string> cond = new Dictionary<string, string>();
            cond.Add("COUNT_MA", "外勞");
            cond.Add("ORINGINAL_ROTE", "原始班別");
            cond.Add("ATT_ROTE", "出勤班別");
            cond.Add("DI", "直間接");
            cond.Add("BTIME", "開始時間");
            cond.Add("ETIME", "結束時間");
            CheckConditionType("OtBonusConditionType", cond);
        }
        void CheckConditionType(string CheckType, Dictionary<string, string> cond)
        {
            var sql = (from a in db.MTCODE where a.CATEGORY == CheckType select a).ToDictionary(p => p.CODE, p => p.NAME);
            foreach (var it in cond)
            {
                if (!sql.ContainsKey(it.Key))
                {
                    JBModule.Data.Linq.MTCODE mt = new JBModule.Data.Linq.MTCODE();
                    mt.CATEGORY = CheckType;
                    mt.CODE = it.Key;
                    mt.SORT = 1;
                    mt.NAME = it.Value;
                    mt.DISPLAY = true;
                    db.MTCODE.InsertOnSubmit(mt);
                }
            }
            db.SubmitChanges();
        }
    }

    public class OtBonusCalc
    {
        public Dictionary<string, string> ConditionList = null;
        public Dictionary<string, List<string>> sqlBaseByBaseList = null;
        public Dictionary<int, string> SCRIPTList = null;
        public List<JBModule.Data.Linq.ROTE_BONUS> roteBonusList = null;
        public List<JBModule.Data.Linq.CALC_CONDITION> calcCondList = null;
        string Source = "RoteBonusConditionType";
        public static string COUNT_MA = "COUNT_MA";
        public static string ATT_ROTE = "ATT_ROTE";
        public static string DI = "DI";
        public static string BTIME = "BTIME";
        public static string ETIME = "ETIME";
        public static string JOB = "JOB";
        public static string ORINGINAL_ROTE = "ORINGINAL_ROTE";
        public OtBonusCalc()
        {
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            ConditionList = new Dictionary<string, string>();
            sqlBaseByBaseList = new Dictionary<string, List<string>>();
            SCRIPTList = new Dictionary<int, string>();
            var sqlBaseByBase = (from a in db.SALCODE
                                 join m in db.MTCODE on a.SALBASE equals m.CODE
                                 //join c in db.SALBASE on a.SALBASE equals c.AUTO.ToString()
                                 where m.CATEGORY == "CALC_REF_TYPE"
                                 group new { m.NAME, a.SAL_CODE } by m.NAME).ToList();
            foreach (var item in sqlBaseByBase)
            {
                sqlBaseByBaseList.Add(item.Key, item.Select(p => p.SAL_CODE).ToList());
            }

            SCRIPTList = db.SALFUNCTION.ToDictionary(p => p.AUTO, p => p.SCRIPT);

        }
        bool CheckCondition(string RoteBonusAuto)
        {
            var calCondData = calcCondList.Where(p => p.CODE == RoteBonusAuto);
            if (calCondData.Any())
            {
                var gp = calCondData.GroupBy(p => p.COND_TYPE);
                foreach (var it in gp)
                {
                    if (ConditionList.ContainsKey(it.Key))//輸入的條件值有要判斷
                    {
                        bool check = false;
                        foreach (var r in it)//相同類別的作群組，做OR的判斷
                        {
                            switch (r.CONDITION)
                            {
                                case "=":
                                    if (ConditionList[it.Key] == r.VALUE1)
                                        check = true;
                                    break;
                                case "<>":
                                    if (ConditionList[it.Key] != r.VALUE1)
                                        check = true;
                                    break;
                            }
                            if (check) break;
                        }
                        if (!check) return false;//外圈是AND，只要有一個條件FALSE就會FALSE
                    }
                }
                return true;//如果有條件，但是到最後都沒有RETURN FALSE,就是TRUE
            }
            else//未設定條件的情況代表不卡判斷
            {
                return true;
            }

        }
        /// <summary>
        /// 每日
        /// </summary>
        /// <param name="Nobr"></param>
        /// <param name="Bdate"></param>
        /// <param name="roteBonus"></param>
        /// <returns></returns>
        private decimal CalcSalFunction(string Nobr, DateTime Bdate, string roteBonus)
        {
            decimal amt = 0;
            try
            {
                JBModule.Data.CalcSalaryByFunction cs = new JBModule.Data.CalcSalaryByFunction();
                amt = cs.GetCalcAttMsg("ATT", Nobr, Bdate, roteBonus).Sum(p => p.Amt);
            }
            catch { }
            return amt;
        }

        private decimal CalcBySalFunction(string Nobr, DateTime Bdate,string Btime, string Etime, string SALFUNCTION, Dictionary<string, string> RefDic, ref Dictionary<string, string> SalFuncParam, ref Dictionary<string, object> SalFuncValue)
        {
            decimal amt = 0;
            try
            {
                JBModule.Data.CalcSalaryByFunction cs = new JBModule.Data.CalcSalaryByFunction();
                JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
                Microsoft.JScript.Vsa.VsaEngine Engine = Microsoft.JScript.Vsa.VsaEngine.CreateEngine();
                int auto = int.Parse(SALFUNCTION);
                //var sql = db.SALFUNCTION.Where(p => p.AUTO == auto).Single().SCRIPT;
                object reslut = null;
                var cont = SCRIPTList[auto];//sql;
                decimal defDecimal = 0;
                try
                {
                    //var sqlBaseByBase = (from a in db.SALCODE
                    //                    join m in db.MTCODE on a.SALBASE equals m.CODE
                    //                    //join c in db.SALBASE on a.SALBASE equals c.AUTO.ToString()
                    //                    where m.CATEGORY == "CALC_REF_TYPE"
                    //                    group new { m.NAME, a.SAL_CODE } by m.NAME).ToList();

                    //固定取代的運算值
                    Dictionary<string, string> Repdic = new Dictionary<string, string>();
                    Repdic.Add("{CalcNobr}", Nobr);
                    //Repdic.Add("{CalcYymm}", Yymm);
                    Repdic.Add("{CalcAttDateB}", Bdate.ToShortDateString());
                    Repdic.Add("{CalcAttDateE}", Bdate.ToShortDateString());
                    Repdic.Add("{CalcSalDateB}", Bdate.ToShortDateString());
                    Repdic.Add("{CalcSalDateE}", Bdate.ToShortDateString());
                    Repdic.Add("{CalcBtime}", Btime.ToString());
                    Repdic.Add("{CalcEtime}", Etime.ToString());
                    foreach (var sqlitem in sqlBaseByBaseList)//sqlBaseByBase)
                    {
                        Repdic.Add("{" + sqlitem.Key + "}", cs.TransQuery(Nobr, sqlitem.Value, Bdate));//.Select(p => p.SAL_CODE).ToList(), Bdate));
                    }

                    if (SalFuncParam.Values.Count > 0)
                    {
                        Dictionary<string, string> TempSalFunc = new Dictionary<string, string>();
                        foreach (var item in SalFuncParam)
                        {
                            string newString = item.Value;
                            foreach (var it in Repdic)
                            {
                                newString = newString.Replace(it.Key, it.Value);
                            }
                            newString = cs.GetSqlQueryValue(db, newString);
                            TempSalFunc.Add(item.Key, newString);
                        }
                        string FuncHash = SALFUNCTION;
                        foreach (var item in TempSalFunc)
                        {
                            if (item.Value != null)
                                FuncHash += item.Key.ToString() + item.Value.ToString();
                            else
                                FuncHash += item.Key.ToString() + "null";
                        }

                        if (SalFuncValue.ContainsKey(FuncHash))
                            reslut = SalFuncValue[FuncHash];
                        else
                        {
                            cont = cs.TransString(cont, RefDic, Repdic, TempSalFunc);
                            reslut = Microsoft.JScript.Eval.JScriptEvaluate(cont, Engine);
                            SalFuncValue.Add(FuncHash, reslut);
                        }
                    }
                    else
                    {
                        cont = cs.TransString(cont, RefDic, Repdic, ref SalFuncParam);
                        reslut = Microsoft.JScript.Eval.JScriptEvaluate(cont, Engine);
                        string FuncHash = SALFUNCTION;
                        Dictionary<string, string> TempSalFunc = new Dictionary<string, string>();
                        foreach (var item in SalFuncParam)
                        {
                            string newString = item.Value;
                            foreach (var it in Repdic)
                            {
                                newString = newString.Replace(it.Key, it.Value);
                            }
                            newString = cs.GetSqlQueryValue(db, newString);
                            TempSalFunc.Add(item.Key, newString);
                        }
                        foreach (var item in TempSalFunc)
                            FuncHash += item.Key.ToString() + item.Value.ToString();
                        SalFuncValue.Add(FuncHash, reslut);
                    }
                }
                catch { }
                amt += reslut == null ? 0M : Decimal.TryParse(reslut.ToString(), out defDecimal) ? Convert.ToDecimal(reslut) : 0M;
            }
            catch (Exception e)
            {


            }
            return amt;
        }

        public List<JBModule.Data.Linq.SALATT> Calc(string BTIME, string ETIME, JBModule.Data.Linq.ROTE rote, bool OnJob, string Nobr, DateTime Bdate, string Source, string Calc_type, Dictionary<string, string> RefDic
            , ref Dictionary<string, Dictionary<string, string>> SalFuncParamsList, ref Dictionary<string, object> SalFuncValue)
        {
            List<JBModule.Data.Linq.SALATT> salattList = new List<JBModule.Data.Linq.SALATT>();
            var BonusData = roteBonusList.Where(p => p.ROTE == rote.ROTE1);
            foreach (var it in BonusData)
            {
                JBModule.Data.Linq.SALATT sa = new JBModule.Data.Linq.SALATT();
                sa.NOTE = "";
                decimal TotalHours = 0;
                decimal amt = 0;
                if (!string.IsNullOrWhiteSpace(it.SALFUNCTION))
                {
                    Dictionary<string, string> SalFuncParam = new Dictionary<string, string>();
                    if (!SalFuncParamsList.ContainsKey(it.SALFUNCTION))
                        SalFuncParamsList.Add(it.SALFUNCTION, SalFuncParam);
                    else
                        SalFuncParam = SalFuncParamsList[it.SALFUNCTION];
                    amt = CalcBySalFunction(Nobr, Bdate, BTIME, ETIME, it.SALFUNCTION, RefDic, ref SalFuncParam, ref SalFuncValue);
                    sa.NOTE += string.Format("[SALFUNCTION={0},{1},{2},{3}]", it.SALFUNCTION, Nobr.ToString(), Bdate.ToString(), it.AUTO.ToString());

                    //if(value == 0) continue;
                }
                else
                {
                    if (CheckCondition(it.AUTO.ToString()))
                    {
                        //JBTools.Intersection its = new JBTools.Intersection();
                        Intersection its = new Intersection();
                        if (OnJob)
                            its.Insert(rote.ON_TIME, rote.OFF_TIME);
                        its.Insert(it.STR_B, it.STR_E);
                        its.Insert(BTIME, ETIME, rote.ALLLATES);
                        TotalHours = its.GetHours();
                        Dictionary<string, string> restTime = new Dictionary<string, string>();
                        if (!string.IsNullOrWhiteSpace(rote.RES_B_TIME) && !string.IsNullOrWhiteSpace(rote.RES_E_TIME)) restTime.Add(rote.RES_B_TIME, rote.RES_E_TIME);
                        if (!string.IsNullOrWhiteSpace(rote.RES_B2_TIME) && !string.IsNullOrWhiteSpace(rote.RES_E2_TIME)) restTime.Add(rote.RES_B2_TIME, rote.RES_E2_TIME);
                        if (!string.IsNullOrWhiteSpace(rote.RES_B3_TIME) && !string.IsNullOrWhiteSpace(rote.RES_E3_TIME)) restTime.Add(rote.RES_B3_TIME, rote.RES_E3_TIME);
                        if (!string.IsNullOrWhiteSpace(rote.RES_B4_TIME) && !string.IsNullOrWhiteSpace(rote.RES_E4_TIME)) restTime.Add(rote.RES_B4_TIME, rote.RES_E4_TIME);
                        if (!it.CHECK6)
                        {
                            foreach (var item in restTime)
                            {
                                JBTools.Intersection itsRest = new JBTools.Intersection();
                                itsRest.Inert(it.STR_B, it.STR_E);
                                itsRest.Inert(rote.ON_TIME, rote.OFF_TIME);
                                itsRest.Inert(item.Key, item.Value);
                                itsRest.Inert(BTIME, ETIME);
                                TotalHours -= itsRest.GetHours();
                            }
                        }
                        TotalHours = JBTools.NumbericConvert.RangeInterval(TotalHours, 0.5M, JBTools.NumbericConvert.DigitalMode.Floor);
                        if (it.CHECK2)
                        {
                            amt = JBTools.NumbericConvert.RangeInterval(TotalHours * it.AMT / rote.WK_HRS, 0.5M, JBTools.NumbericConvert.DigitalMode.Round);
                            sa.NOTE += string.Format("[TotalHours*it.AMT/rote.WK_HRS ={0}*{1}/{2}]", TotalHours.ToString(), it.AMT.ToString(), rote.WK_HRS.ToString());
                        }
                        else
                        {
                            amt = it.AMT;
                            sa.NOTE += string.Format("[AUTO={0},AMT={1}]", it.AUTO.ToString(), it.AMT.ToString());
                        }
                        //amt += TotalHours * it.AMT;
                    }
                    //須做滿
                    if (it.CHECK1)
                    {
                        if (!(it.STR_B.CompareTo(BTIME) >= 0 && it.STR_E.CompareTo(ETIME) <= 0))//沒有包覆
                        {
                            amt = 0;
                            sa.NOTE += string.Format("[[CHECK1=True=>!(({0}).CompareTo({1}) >=0 && ({2}).CompareTo({3})<=0)]", it.STR_B.ToString(), BTIME.ToString(), it.STR_E.ToString(), ETIME.ToString());
                            //continue;
                        }
                    }
                    else
                    {
                        if (!(it.STR_B.CompareTo(ETIME) < 0 && it.STR_E.CompareTo(BTIME) > 0))//沒有交集
                        {
                            amt = 0;
                            sa.NOTE += string.Format("[[CHECK1=false=>!(({0}).CompareTo({1}) <0 && ({2}).CompareTo({3})>0)]", it.STR_B.ToString(), BTIME.ToString(), it.STR_E.ToString(), ETIME.ToString());
                            //continue;
                        }
                        //判斷時數
                        if (!(it.VALUE1 <= TotalHours && it.VALUE2 >= TotalHours))
                        {
                            amt = 0;
                            sa.NOTE += string.Format("[[CHECK1=false=>!({0}<={1} && {2}>={1})]", it.VALUE1.ToString(), TotalHours.ToString(), it.VALUE2.ToString());
                            //continue;
                        }
                    }
                }
                if (amt == 0 && sa.NOTE == "")
                    continue;

                amt = Math.Round(amt, MidpointRounding.AwayFromZero);
                sa.ADATE = Bdate;
                sa.AMT = amt;
                sa.BTIME = BTIME;//it.STR_B;
                sa.ETIME = ETIME;//it.STR_E;
                sa.KEY_DATE = DateTime.Now;
                sa.KEY_MAN = MainForm.USER_NAME;
                sa.NOBR = Nobr;
                //sa.NOTE += "=" + amt.ToString();
                sa.ROTE = rote.ROTE1;
                sa.SAL_CODE = it.SAL_CODE;
                sa.SEQ = "";
                sa.SOURCE = Source;
                sa.CALC_TYPE = Calc_type;
                sa.YYMM = "";
                salattList.Add(sa);
            }
            return salattList;
        }

        private class Intersection
        {
            DateTime TempA, TempB;
            public Intersection()
            {
                TempA = DateTime.MinValue;
                TempB = DateTime.MaxValue;
            }
            public void Insert(DateTime T1, DateTime T2)
            {
                if (TempA < T1) TempA = T1;
                if (TempB > T2) TempB = T2;
            }
            public void Insert(string T1, string T2)
            {
                DateTime TT1, TT2;
                if (T1.Trim().Length > 0)
                    TT1 = DateTime.MinValue.AddTime(T1);
                else TT1 = DateTime.MinValue.AddTime("0000");

                if (T2.Trim().Length > 0)
                    TT2 = DateTime.MinValue.AddTime(T2);
                else TT2 = DateTime.MinValue.AddTime("4800");

                if (TempA < TT1) TempA = TT1;
                if (TempB > TT2) TempB = TT2;
            }
            public void Insert(string T1, string T2, decimal T1_offset)
            {
                DateTime TT1, TT2;
                if (T1.Trim().Length > 0)
                    TT1 = DateTime.MinValue.AddTime(T1);
                else TT1 = DateTime.MinValue.AddTime("0000");

                if (T2.Trim().Length > 0)
                    TT2 = DateTime.MinValue.AddTime(T2);
                else TT2 = DateTime.MinValue.AddTime("4800");

                if (TempA.AddMinutes((double)T1_offset) < TT1)
                {
                    TempA = TT1;
                }

                if (TempB > TT2)
                {
                    TempB = TT2;
                }
            }
            public DateTime TimeBegin
            {
                get { return TempA; }
            }
            public DateTime TimeEnd
            {
                get { return TempB; }
            }
            public bool HasIntersection()
            {
                return TempA <= TempB;
            }
            public TimeSpan IntersectionTimeSpan
            {
                get { return TempB - TempA; }
            }
            public int GetDays()
            {
                if (HasIntersection())
                    return Convert.ToInt32((TempB.Date - TempA.Date).TotalDays) + 1;
                else return 0;
            }
            public decimal GetHours()
            {
                if (HasIntersection())
                    return Convert.ToDecimal(IntersectionTimeSpan.TotalHours);
                else return 0;
            }
            public decimal GetMinutes()
            {
                if (HasIntersection())
                    return Convert.ToDecimal(IntersectionTimeSpan.TotalMinutes);
                else return 0;
            }
        }

        public bool DeleteSalAtt(List<string> EmpList, DateTime Bdate, DateTime Edate, List<string> CalcTypeList, out string errMsg)
        {
            errMsg = "";
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            try
            {
                foreach (var item in EmpList.Split(1000))
                {
                    var sql = (from a in db.SALATT
                               where item.Contains(a.NOBR)
                               && a.ADATE >= Bdate && a.ADATE <= Edate
                               && CalcTypeList.Contains(a.CALC_TYPE)
                               select a).Distinct().ToList();
                    if (sql.Any())
                    {
                        db.SALATT.DeleteAllOnSubmit(sql);
                        db.SubmitChanges();
                    } 
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
            return true;
        }

        public bool DeleteSalAtt(string Nobr_B, string Nobr_E,string DEPT_B,string DEPT_E , DateTime Bdate, DateTime Edate, string CalcType, out string errMsg)
        {
            errMsg = "";
            JBModule.Data.Linq.HrDBDataContext db = new JBModule.Data.Linq.HrDBDataContext();
            try
            {
                var sql = (from a in db.SALATT
                          join b in db.BASETTS on a.NOBR equals b.NOBR
                          join c in db.DEPT on b.DEPT equals c.D_NO
                          where a.NOBR.CompareTo(Nobr_B) >= 0 && a.NOBR.CompareTo(Nobr_E) <= 0
                          && c.D_NO_DISP.CompareTo(DEPT_B) >= 0 && c.D_NO_DISP.CompareTo(DEPT_E) <= 0
                          && a.ADATE >= Bdate && a.ADATE <= Edate
                          && a.CALC_TYPE == CalcType
                          //&& db.GetFilterByNobr(a.NOBR, MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Value
                          && db.UserReadDataGroupList(MainForm.USER_ID, MainForm.COMPANY, MainForm.ADMIN).Select(p => p.DATAGROUP).Contains(b.SALADR)
                           select a).Distinct().ToList();
                if (sql.Any())
                {
                    db.SALATT.DeleteAllOnSubmit(sql);
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                return false;
            }
            return true;
        }
    }
}
