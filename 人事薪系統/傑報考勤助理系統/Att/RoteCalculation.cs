using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBHR.Sal.Core
{
    /**
     * 旭源輪班津貼規則
     * 1.固定金額，平日滿8小時，假日滿8.5給全部，不滿者依比例給予
     * 2.依下班時段00～3：00＝100元,3：30～5：00＝125元,5：30～8：00＝150元
     * 當天有請假就不給(不限任何假別)
     * 
     * */
    public class RoteCalculation
    {
        List<JBModule.Data.Linq.ROTE_BONUS> roteBonusList = null;
        List<JBModule.Data.Linq.CALC_CONDITION> calcCondList = null;
        List<JBModule.Data.Linq.ROTE> RoteList = null;
        JBModule.Data.Linq.HrDBDataContext db = null;
        public RoteCalculation()
        {
            db = new JBModule.Data.Linq.HrDBDataContext();
            roteBonusList = db.ROTE_BONUS.ToList();
            calcCondList = db.CALC_CONDITION.ToList();
            RoteList = db.ROTE.ToList();
        }
        public RoteBonusCalc CreateRoteBonusCalc()
        {
            RoteBonusCalc obc = new RoteBonusCalc();
            obc.calcCondList = calcCondList.Where(p => p.SOURCE == "RoteBonusConditionType").ToList();
            obc.roteBonusList = roteBonusList;
            obc.RoteList = RoteList;
            return obc;
        }
        public void CheckRoteBonusConditionType()
        {
            Dictionary<string, string> cond = new Dictionary<string, string>();
            cond.Add("COUNT_MA", "外勞");
            cond.Add("ATT_ROTE", "出勤班別");
            cond.Add("DI", "直間接");
            cond.Add("BTIME", "開始時間");
            cond.Add("ETIME", "結束時間");
            CheckConditionType("RoteBonusConditionType", cond);
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

    public class RoteBonusCalc
    {
        public Dictionary<string, string> ConditionList = null;
        public List<JBModule.Data.Linq.ROTE_BONUS> roteBonusList = null;
        public List<JBModule.Data.Linq.CALC_CONDITION> calcCondList = null;
        public List<JBModule.Data.Linq.ROTE> RoteList = null;
        string Source = "RoteBonusConditionType";
        public static string COUNT_MA = "COUNT_MA";
        public static string ATT_ROTE = "ATT_ROTE";
        public static string DI = "DI";
        public static string BTIME = "BTIME";
        public static string ETIME = "ETIME";
        public RoteBonusCalc()
        {
            ConditionList = new Dictionary<string, string>();
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
        public decimal Calc(decimal Wk_Hours, string BTIME, string ETIME, string sRote)
        {
            //List<JBModule.Data.Linq.SALATT> salattList = new List<JBModule.Data.Linq.SALATT>();
            decimal TotalAmt = 0;
            var rote = RoteList.Where(p => p.ROTE1 == sRote).First();
            var BonusData = roteBonusList.Where(p => p.ROTE == rote.ROTE1).OrderByDescending(p=>p.SORT);
            foreach (var it in BonusData)
            {
                if (CheckCondition(it.AUTO.ToString()))
                {
                    if (it.CHECK1)//下班時間介於
                    {
                        if (it.STR_B.CompareTo(ETIME) <= 0 && it.STR_E.CompareTo(ETIME) >= 0)//符合條件
                        {
                            if (TotalAmt < it.AMT)//取金額最多的
                                TotalAmt = it.AMT;
                        }
                    }
                    else if (it.CHECK2)//滿工時
                    {
                        decimal amt = 0;
                        if(Wk_Hours>=it.VALUE1)                        
                            amt = it.AMT;
                        if (TotalAmt < amt)//取金額最多的
                            TotalAmt = amt;
                    }
                }
            }
            return Math.Round(TotalAmt, MidpointRounding.AwayFromZero);
        }

    }
}
