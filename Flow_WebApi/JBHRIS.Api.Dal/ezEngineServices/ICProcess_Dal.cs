using JBHRIS.Api.Dto.Vdb;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Dal.ezEngineServices
{
    public interface ICProcess_Dal
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idProcess"></param>
        /// <param name="idProcessNode"></param>
        /// <param name="idProcessCheck"></param>
        /// <param name="errorType"></param>
        /// <param name="errorMsg"></param>
        public void WriteProcessException(int idProcess, int idProcessNode, int idProcessCheck, MsgType errorType, string errorMsg);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="idProcessNode_Prior"></param>
        /// <param name="idProcess"></param>
        /// <param name="idFlowNode"></param>
        /// <returns></returns>
        public int CreateProcessNode(int idProcessNode_Prior, int idProcess, string idFlowNode);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idProcessNode_Prior"></param>
        /// <param name="idProcess"></param>
        /// <param name="idFlowNode"></param>
        /// <param name="Man_Default"></param>
        /// <param name="Man_Agent"></param>
        /// <param name="idEmpSource"></param>
        /// <returns></returns>
        public int WriteProcessNodeAndCheck(int idProcessNode_Prior, int idProcess, string idFlowNode, CMan Man_Default, CMan Man_Agent, string idEmpSource);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetProcessID();


    }
}
