using JBHRIS.Api.Dto.Vdb;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBHRIS.Api.Service.Interface.ezEngineServices
{
    public interface ICOrgInterface
    {
        /// <summary>
        /// 取得代理人
        /// </summary>
        /// <param name="idProcess"></param>
        /// <param name="Role_idSource"></param>
        /// <param name="Emp_idSource"></param>
        /// <returns></returns>
        CMan GetAgent(int idProcess, string Role_idSource, string Emp_idSource);



        /// <summary>
        /// 取得主管
        /// </summary>
        /// <param name="idProcess"></param>
        /// <param name="Role_idMinion"></param>
        /// <param name="EmpSameUp"></param>
        /// <returns></returns>
        CMan GetManager(int idProcess, string Role_idMinion, bool EmpSameUp = true);


        /// <summary>
        /// 判斷是否是主管
        /// </summary>
        /// <param name="Role"></param>
        /// <param name="Nobr"></param>
        /// <returns></returns>
        bool IsManage(string Role, string Nobr);


        /// <summary>
        /// 檢驗主官是否為該部門的主管 下一關的部門path應該被上一關的部門path包含
        /// </summary>
        /// <param name="OldRole"></param>
        /// <param name="NewRole"></param>
        /// <returns></returns>
        bool IsDeptPathTrue(string OldRole, string NewRole);




        /// <summary>
        /// 取得流程起始者
        /// </summary>
        /// <param name="idProcess"></param>
        /// <returns></returns>
        CMan GetFlowInit(int idProcess);


        /// <summary>
        /// 會簽起始者
        /// </summary>
        /// <param name="idProcess"></param>
        /// <param name="idFlowNode_MultiStart"></param>
        /// <returns></returns>
        CMan GetMultiInit(int idProcess, string idFlowNode_MultiStart);


        /// <summary>
        /// 自訂簽核者
        /// </summary>
        /// <param name="idFlowNode_Custom"></param>
        /// <returns></returns>
        CMan GetCustom(string idFlowNode_Custom);


        /// <summary>
        /// 動態簽核者
        /// </summary>
        /// <param name="idProcess"></param>
        /// <param name="idFlowNode_Dynamic"></param>
        /// <returns></returns>
        CMan GetDynamic(int idProcess, string idFlowNode_Dynamic);


        /// <summary>
        /// 代理起始者
        /// </summary>
        /// <param name="idProcess"></param>
        /// <returns></returns>
        CMan GetAgentInit(int idProcess);



    }
}
