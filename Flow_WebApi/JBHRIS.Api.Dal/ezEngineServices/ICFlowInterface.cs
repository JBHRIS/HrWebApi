using JBHRIS.Api.Dto.Vdb;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.ezEngineServices
{
    public interface ICFlowInterface
    {

        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="property"></param>
        /// <returns></returns>
        public object GetPropertyValue(object obj, string property);


        /// <summary>
        /// 判斷是否要給下一關主管簽核 僅限主管審核節點使用
        /// 未完成
        /// </summary>
        /// <param name="idProcess"></param>
        /// <param name="idProcessNode_Source"></param>
        /// <param name="idProcessCheck_Source"></param>
        /// <param name="idFlowNode"></param>
        /// <returns></returns>
        public bool IsNextManage(int idProcess, int idProcessNode_Source, int idProcessCheck_Source, string idFlowNode);


        /// <summary>
        /// 從 Source 節點，取得 Target 節點集合
        /// 未完成
        /// </summary>
        /// <param name="idProcess"></param>
        /// <param name="idProcessNode_Source"></param>
        /// <param name="idProcessCheck_Source"></param>
        /// <param name="idFlowTree"></param>
        /// <param name="idFlowNode_Source"></param>
        /// <returns></returns>
        public List<string> GetLinkNextNode(int idProcess, int idProcessNode_Source, int idProcessCheck_Source, string idFlowTree, string idFlowNode_Source);


        /// <summary>
        /// 取得AND條件字串
        /// 未完成
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="fieldType"></param>
        /// <param name="criteria"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public string GetCriteriaString(string fieldName, string fieldType, string criteria, string minValue, string maxValue);


        /// <summary>
        /// GetLinkNextNode 未完成
        /// </summary>
        /// <param name="idProcess"></param>
        /// <param name="idProcessNode_Source"></param>
        /// <param name="idProcessCheck_Source"></param>
        /// <param name="idFlowTree"></param>
        /// <param name="idFlowNodeSource"></param>
        /// <param name="idRoleSource"></param>
        /// <param name="idEmpSource"></param>
        /// <param name="lstNode_Next"></param>
        /// <param name="EmpSameUp">遇到本點與上點審核者同一人時 是否要繼續向上</param>
        /// <param name="Man_Default">強迫填入審核者</param>
        /// <param name="Man_Agent">強迫填入代理審核者</param>
        /// <param name="FlowStart">第一次進入</param>
        /// <returns></returns>
        public bool GoToNextNode(int idProcess, int idProcessNode_Source, int idProcessCheck_Source,
            string idFlowTree, string idFlowNodeSource, string idRoleSource, string idEmpSource, List<string> lstNode_Next, bool EmpSameUp = true, CMan Man_Default = null, CMan Man_Agent = null, bool FlowStart = false);






        /// <summary>   
        /// 動態呼叫Web Service  
        /// 未完成
        /// </summary>   
        /// <param name="pUrl">WebService的http形式的位址，EX:http://www.yahoo.com/Service/Service.asmx </param>   
        /// <param name="pNamespace">欲呼叫的WebService的namespace</param>   
        /// <param name="pClassname">欲呼叫的WebService的class name</param>   
        /// <param name="pMethodname">欲呼叫的WebService的method name</param>   
        /// <param name="pArgs">參數列表，請將每個參數分別放入object[]中</param>   
        /// <returns>WebService的執行結果</returns>   
        /// <remarks>   
        /// 如果呼叫失敗，將會拋出Exception。請呼叫的時候，適當截獲異常。   
        /// 目前知道有兩個地方可能會發生異常：   
        /// 1、動態構造WebService的時候，CompileAssembly失敗。   
        /// 2、WebService本身執行失敗。   
        /// </remarks>   
        public object InvokeWebservice(string pUrl, string @pNamespace, string pClassname, string pMethodname, object[] pArgs);


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool GetisFinishOK();
    }
}
