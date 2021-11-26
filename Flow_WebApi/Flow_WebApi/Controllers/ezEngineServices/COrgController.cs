using JBHRIS.Api.Dal.ezEngineServices;
using JBHRIS.Api.Dto.Vdb;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Flow_WebApi.Controllers.ezEngineServices
{
    [Route("api/[controller]")]
    [ApiController]
    public class COrgController : ControllerBase
    {

        private ICOrg_Dal _ICOrgInterface;

        public COrgController(ICOrg_Dal cOrgInterface)
        {
            this._ICOrgInterface = cOrgInterface;
        }


        /// <summary>
        /// 取得代理人
        /// </summary>
        /// <param name="idProcess"></param>
        /// <param name="Role_idSource"></param>
        /// <param name="Emp_idSource"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAgent")]
        public CMan GetAgent(int idProcess, string Role_idSource, string Emp_idSource)
        {
            return this._ICOrgInterface.GetAgent( idProcess,  Role_idSource,  Emp_idSource);
        }


        /// <summary>
        /// 取得主管
        /// </summary>
        /// <param name="idProcess"></param>
        /// <param name="Role_idMinion"></param>
        /// <param name="EmpSameUp"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetManager")]
        public CMan GetManager(int idProcess, string Role_idMinion, bool EmpSameUp = true)
        {
            return this._ICOrgInterface.GetManager( idProcess,  Role_idMinion, EmpSameUp );
        }


        /// <summary>
        /// 判斷是否是主管
        /// </summary>
        /// <param name="Role"></param>
        /// <param name="Nobr"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("IsManage")]
        public bool IsManage(string Role, string Nobr)
        {
            return this._ICOrgInterface.IsManage( Role, Nobr);
        }


        /// <summary>
        /// 檢驗主官是否為該部門的主管 下一關的部門path應該被上一關的部門path包含
        /// </summary>
        /// <param name="OldRole"></param>
        /// <param name="NewRole"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("IsDeptPathTrue")]
        public bool IsDeptPathTrue(string OldRole, string NewRole)
        {
            return this._ICOrgInterface.IsDeptPathTrue( OldRole,  NewRole);
        }


        /// <summary>
        /// 取得流程起始者
        /// </summary>
        /// <param name="idProcess"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetFlowInit")]
        public CMan GetFlowInit(int idProcess)
        {
            return this._ICOrgInterface.GetFlowInit(idProcess);
        }

        /// <summary>
        /// 會簽起始者
        /// </summary>
        /// <param name="idProcess"></param>
        /// <param name="idFlowNode_MultiStart"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetMultiInit")]
        public CMan GetMultiInit(int idProcess, string idFlowNode_MultiStart)
        {
            return this._ICOrgInterface.GetMultiInit(idProcess, idFlowNode_MultiStart);
        }


        /// <summary>
        /// 自訂簽核者
        /// </summary>
        /// <param name="idFlowNode_Custom"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCustom")]
        public CMan GetCustom(string idFlowNode_Custom)
        {
            return this._ICOrgInterface.GetCustom(idFlowNode_Custom);
        }

        /// <summary>
        /// 動態簽核者
        /// </summary>
        /// <param name="idProcess"></param>
        /// <param name="idFlowNode_Dynamic"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetDynamic")]
        public CMan GetDynamic(int idProcess, string idFlowNode_Dynamic)
        {
            return this._ICOrgInterface.GetDynamic( idProcess,  idFlowNode_Dynamic);
        }


        /// <summary>
        /// 代理起始者
        /// </summary>
        /// <param name="idProcess"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAgentInit")]
        public CMan GetAgentInit(int idProcess)
        {
            return this._ICOrgInterface.GetAgentInit(idProcess);
        }




    }
}
