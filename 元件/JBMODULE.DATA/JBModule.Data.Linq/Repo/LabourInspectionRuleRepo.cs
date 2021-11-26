using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JBModule.Data.Repo
{
    public class LabourInspectionRuleRepo
    {
        LabourInspectionRuleCondition _cond;
        public List<int> CheckDateSequence;
        public LabourInspectionRuleRepo(LabourInspectionRuleCondition cond)
        {
            _cond = cond;
            CheckDateSequence = new List<int>();
        }
        public List<JBModule.Data.Linq.OT_B> CheckOtLabourInspectionRule(List<JBModule.Data.Linq.OT_B> OtList)
        {
            List<JBModule.Data.Linq.OT_B> results = OtList.ToList();
            foreach (var it in _cond.CheckRuleList)
            {
                it.Parameters = _cond.Parameters;
                 results = it.ValidateOT(results);

            }
            return results;
        }
        public List<JBModule.Data.Linq.OT_B> ConvertOtToOtB(List<JBModule.Data.Linq.OT_Simple> OtList)
        {
            List<JBModule.Data.Linq.OT_B> results = new List<Linq.OT_B>();
            foreach (var ot in OtList)
            {
                JBModule.Data.Linq.OT_B result = ot.ConvertToJson().ConvertJsonTo<JBModule.Data.Linq.OT_B>();
                results.Add(result);
            }
            return results;
        }
    }
    public class LabourInspectionRuleCondition
    {
        public LabourInspectionRuleCondition()
        {
            CheckRuleList = new List<ILabourCheckRule>();
        }
        public List<JBModule.Data.Linq.OT_Simple> SourceOT { get; set; }
        public List<ILabourCheckRule> CheckRuleList { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
    }
    public class LabourInspectionTimeDto
    {
        public string OnTime { get; set; }
        public string OffTime { get; set; }
        public string OnTime24 { get; set; }
        public string OffTime24 { get; set; }
    }
    public interface ILabourCheckRule
    {
        /// <summary>
        /// 驗證加班規則
        /// </summary>
        /// <param name="Source">加班資料(處理前)</param>
        /// <returns>加班資料(處理後)</returns>
        List<JBModule.Data.Linq.OT_B> ValidateOT(List<JBModule.Data.Linq.OT_B> Source);
         Dictionary<string, object> Parameters { get; set; }
    }
}
