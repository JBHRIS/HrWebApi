using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace JBModule.Data.Factory.Formula
{
    public class FormulaFunctionRepo
    {
        FormulaFunctionCondition _cond;
        public FormulaFunctionRepo(FormulaFunctionCondition cond)
        {
            _cond = cond;
        }
        public Dictionary<string, object> CheckFormulaFunction(Dictionary<string, object> Parameters)
        {
            Dictionary<string, object> results = Parameters;
            foreach (var it in _cond.GetDataList)
            {
                //it.Parameters = _cond.Parameters;
                results.Add(it.GetKey(), it.GetData());
            }
            return results;
        }
    }

    public class FormulaFunctionCondition
    {
        public FormulaFunctionCondition()
        {
            GetDataList = new List<IFormulaFunction>();
        }
        public List<IFormulaFunction> GetDataList { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
    }
    public interface IFormulaFunction
    {
        /// <summary>
        /// 驗證規則
        /// </summary>
        /// <returns>錯誤訊息的列表</returns>
        DataTable GetData();
        string GetKey();
        Dictionary<string, object> Parameters { get; set; }
    }
}
