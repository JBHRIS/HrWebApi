using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace JBModule.Data.Repo
{
    public class SalCalcBeforeInspectionRuleRepo
    {
        SalCalcBeforeInspectionRuleCondition _cond;

        public SalCalcBeforeInspectionRuleRepo(SalCalcBeforeInspectionRuleCondition cond)
        {
            _cond = cond;
        }
        public List<DataTable> CheckSalCalcBeforeInspectionRule()
        {
            List<DataTable> results = new List<DataTable>();
            foreach (var it in _cond.CheckRuleList)
            {
                //it.Parameters = _cond.Parameters;
                results.Add(it.Validate());
            }
            return results;
        }
    }
    public class SalCalcBeforeInspectionRuleCondition
    {
        public SalCalcBeforeInspectionRuleCondition()
        {
            CheckRuleList = new List<ISalCalcBeforeCheckRule>();
        }
        //public List<JBModule.Data.Linq.OT_Simple> SourceOT { get; set; }
        public List<ISalCalcBeforeCheckRule> CheckRuleList { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
    }
    public interface ISalCalcBeforeCheckRule
    {
        /// <summary>
        /// 驗證規則
        /// </summary>
        /// <returns>錯誤訊息的列表</returns>
        DataTable Validate();
        Dictionary<string, object> Parameters { get; set; }
    }
}
